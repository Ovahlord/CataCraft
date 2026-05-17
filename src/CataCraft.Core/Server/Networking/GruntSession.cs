// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Net.Sockets;
using CataCraft.Core.Cryptography;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol;
using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Networking;

public sealed class GruntSession : WowSession
{
    protected override int ClientPacketHeaderSize => 1;
    protected override int ServerPacketHeaderSize => 1;

    public SRP6? SRP6 { get; private set; }

    public GruntAuthenticationState GruntAuthenticationState { get; set; } = GruntAuthenticationState.LogonChallenge;

    public GruntSession(TcpClient client) : base(client)
    {
    }

    protected override bool ReadHeader(ref ReadOnlySequence<byte> headerBuffer, out int opcode, out int payloadLength)
    {
        opcode = 0;
        payloadLength = 0;

        SequenceReader<byte> reader = new(headerBuffer);
        if (!reader.TryRead(out byte byteOpcode))
            return false;

        payloadLength = -1;
        opcode = byteOpcode;

        if (!Enum.IsDefined(typeof(GruntOpcodes), (GruntOpcodes)byteOpcode))
            return false;

        Console.WriteLine($"Received packet with opcode ({(GruntOpcodes)opcode}) 0x{opcode:x2} and payload length {payloadLength}");

        return true;
    }

    protected override void ReadPayload(ref ReadOnlySequence<byte> payloadBuffer, int opcode)
    {
        if (GruntPacketDispatcher.TryGetPacketHandler((GruntOpcodes)opcode, out var handler))
        {
            handler.Invoke(payloadBuffer, this);
            return;
        }

        Console.WriteLine($"No packet handler found for Grunt opcode: {(GruntOpcodes)opcode}");
    }

    protected override void WriteHeader(IBufferWriter<byte> writer, int opcode, int payloadSize)
    {
        Span<byte> headerSpan = stackalloc byte[ServerPacketHeaderSize];
        headerSpan[0] = (byte)opcode;
        writer.Write(headerSpan);
    }

    /// <summary>
    /// Loads the game account data from the database and initializes SRP6 instance. If no game account data is found,
    /// the SRP6 instance gets initialized with made up data
    /// found
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> InitializeAccountDataAsync(CancellationToken cancellationToken = default)
    {
        await using LoginDbContext loginDb = new();
        GameAccount? gameAccount = await loginDb.GameAccounts.FirstOrDefaultAsync(ga => ga.AccountName.Equals(AccountName), cancellationToken);

        if (gameAccount != null)
        {
            SRP6 = new SRP6(AccountName, gameAccount.Salt, gameAccount.Verifier);
            GameAccountId = gameAccount.Id;
        }

        return gameAccount != null;
    }
}
