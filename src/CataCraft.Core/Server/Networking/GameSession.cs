// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Buffers.Binary;
using System.Net.Sockets;
using System.Security.Cryptography;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.Realm;
using CataCraft.Core.Server.Protocol;
using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Core.Server.Protocol.Packets.GamePackets;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Networking;

public class GameSession : WowSession
{
    // Properties
    protected override int ClientPacketHeaderSize => ConnectionInitialized ? 6 : 2;
    protected override int ServerPacketHeaderSize => ConnectionInitialized ? 5 : 2;

    public bool PacketCryptInitialized => _packetCrypt != null;
    private bool ConnectionInitialized { get; set; }
    public byte[] AuthSeed { get; private set; } = RandomNumberGenerator.GetBytes(4);
    public Realm Realm { get; private set; }

    public uint[] TutorialBits { get; private set; } = [];
    public byte[] SessionKey { get; private set; } = [];
    public byte AccountExpansionLevel { get; private set; }
    public byte ActiveExpansionLevel { get; private set; }

    // Fields
    private PacketCrypt? _packetCrypt;
    private readonly byte[] _encryptSeed = RandomNumberGenerator.GetBytes(16);
    private readonly byte[] _decryptSeed = RandomNumberGenerator.GetBytes(16);

    public GameSession(TcpClient client, Realm realm) : base(client)
    {
        Realm = realm;
    }

    public async Task<ResponseCodes> LoadGameAccountDataAsync(string accountName)
    {
        if (string.IsNullOrWhiteSpace(accountName))
            return ResponseCodes.AuthUnknownAccount;

        await using LoginDbContext loginDb = new();
        GameAccount? gameAccount = await loginDb.GameAccounts
            .Include(ga => ga.SessionData)
            .Include(ga => ga.Tutorial)
            .FirstOrDefaultAsync(ga => ga.AccountName.Equals(accountName));

        if (gameAccount == null)
            return ResponseCodes.AuthUnknownAccount;

        if (gameAccount.SessionData == null || gameAccount.Tutorial == null)
            return ResponseCodes.AuthFailed;

        GameAccountId = gameAccount.Id;
        AccountName = gameAccount.AccountName;
        SessionKey = gameAccount.SessionData.SessionKey;
        Locale = (ClientLocale)gameAccount.SessionData.ClientLocale;
        TutorialBits = gameAccount.Tutorial.TutorialBits;
        AccountExpansionLevel = gameAccount.ActiveExpansionLevel;
        ActiveExpansionLevel = gameAccount.ActiveExpansionLevel;

        return ResponseCodes.AuthOk;
    }

    protected override bool ReadHeader(ref ReadOnlySequence<byte> headerBuffer, out int opcode, out int payloadLength)
    {
        opcode = 0;
        payloadLength = 0;
        Span<byte> headerSpan = stackalloc byte[ClientPacketHeaderSize];
        headerBuffer.CopyTo(headerSpan);

        // When the header encryption has been initialized, we have to decrypt the incoming headers
        if (_packetCrypt != null && ConnectionInitialized)
            _packetCrypt.DecryptRecv(headerSpan);

        // Extract the payload length
        payloadLength = BinaryPrimitives.ReadUInt16BigEndian(headerSpan.Slice(0, 2));

        // Validate the payload length
        if (payloadLength < 4 || payloadLength > 10240)
            return false;

        // When the client packet is the very first connection initializer we only expect a payload length
        if (!ConnectionInitialized)
            return true;

        // Extract the opcode
        opcode = BinaryPrimitives.ReadInt32LittleEndian(headerSpan.Slice(2, 4));

        // Make sure that the opcode actually exists
        if (!Enum.IsDefined(typeof(GameClientOpcodes), (GameClientOpcodes)opcode))
        {
            Console.WriteLine($"Received packet with undefined opcode: 0x{opcode:X4} and payload length {payloadLength}");
            //return false;
        }

        // The size field of the packet header also contains the size of the opcode - we don't want that
        payloadLength -= sizeof(int);
        Console.WriteLine($"Received packet with opcode ({(GameClientOpcodes)opcode}) 0x{opcode:X4} and payload length {payloadLength}");

        return true;
    }

    protected override void ReadPayload(ref ReadOnlySequence<byte> payloadBuffer, int opcode)
    {
        // The very first packet is a connection initializer
        if (!ConnectionInitialized)
        {
            if (!ClientConnectionInitialize.HandlePacket(payloadBuffer, this))
                return;

            ConnectionInitialized = true;

            // Connection has been successfully established. Initialize the authentication.
            SendAuthChallenge();
            return;
        }

        if (GamePacketsDispatcher.TryGetPacketHandler((GameClientOpcodes)opcode, out var handler))
        {
            handler.Invoke(payloadBuffer, this);
            return;
        }

        Console.WriteLine($"No packet handler found for Game opcode: {(GameClientOpcodes)opcode}");
    }

    protected override void WriteHeader(IBufferWriter<byte> writer, int opcode, int payloadSize)
    {
        if (!ConnectionInitialized)
        {
            Span<byte> connectionInitializeHeader = stackalloc byte[ServerPacketHeaderSize];
            connectionInitializeHeader[0] = (byte)(0xFF & (payloadSize >> 8));
            connectionInitializeHeader[1] = (byte)(0xFF & payloadSize);
            writer.Write(connectionInitializeHeader);
            return;
        }

        int packetSize = payloadSize + sizeof(GameServerOpcodes);
        int headerIndex = 0;

        Span<byte> headerSpan = stackalloc byte[ServerPacketHeaderSize];

        if (packetSize > 0x7FFF)
            headerSpan[headerIndex++] = (byte)(0x80 | (0xFF & (packetSize >> 16)));

        headerSpan[headerIndex++] = (byte)(0xFF & (packetSize >> 8));
        headerSpan[headerIndex++] = (byte)(0xFF & packetSize);

        headerSpan[headerIndex++] = (byte)(0xFF & opcode);
        headerSpan[headerIndex++] = (byte)(0xFF & (opcode >> 8));

        _packetCrypt?.EncryptSend(headerSpan.Slice(0, headerIndex));

        writer.Write(headerSpan.Slice(0, headerIndex));
    }

    private void SendAuthChallenge()
    {
        ServerAuthChallenge packet = new()
        {
            Challenge = BinaryPrimitives.ReadUInt32LittleEndian(AuthSeed),
            DosZeroBits = 1,
            DosChallenge = new uint[8]
        };

        for (int i = 0; i < 4; ++i)
        {
            packet.DosChallenge[i] = BitConverter.ToUInt32(_encryptSeed, i * 4);
            packet.DosChallenge[i + 4] = BitConverter.ToUInt32(_decryptSeed, i * 4);
        }

        EnqueuePacket(ref packet);
    }

    public void InitializePacketCrypt(bool useStaticKeys)
    {
        if (useStaticKeys)
            _packetCrypt = new(SessionKey);
        else
            _packetCrypt = new(SessionKey, _encryptSeed, _decryptSeed);
    }
}
