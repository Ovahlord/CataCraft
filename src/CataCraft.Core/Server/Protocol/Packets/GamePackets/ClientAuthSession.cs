// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Security.Cryptography;
using System.Text;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;
using CataCraft.Core.Utils;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public struct ClientAuthSession
{
    public uint BattlegroupID { get; private set; }
    public sbyte LoginServerType { get; private set; }
    public sbyte BuildType { get; private set; }
    public uint RealmID { get; private set; }
    public ushort Build { get; private set; }
    public uint LocalChallenge { get; private set; }
    public int LoginServerID { get; private set; }
    public uint RegionID { get; private set; }
    public ulong DosResponse { get; private set; }
    public byte[] Digest { get; private set; } = new byte[20];
    public string Account { get; set; } = string.Empty;
    public bool UseIPv6 { get; set; }
    public SecureAddonInfo[] AddonInfo { get; set; } = [];

    private const int MaxSecureAddons = 35;

    private ClientAuthSession(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);

        LoginServerID = reader.ReadInt32();
        BattlegroupID = reader.ReadUInt32();
        LoginServerType = reader.ReadInt8();
        Digest[10] = reader.ReadUInt8();
        Digest[18] = reader.ReadUInt8();
        Digest[12] = reader.ReadUInt8();
        Digest[5] = reader.ReadUInt8();

        DosResponse = reader.ReadUInt64();

        Digest[15] = reader.ReadUInt8();
        Digest[9] = reader.ReadUInt8();
        Digest[19] = reader.ReadUInt8();
        Digest[4] = reader.ReadUInt8();
        Digest[7] = reader.ReadUInt8();
        Digest[16] = reader.ReadUInt8();
        Digest[3] = reader.ReadUInt8();

        Build = reader.ReadUInt16();

        Digest[8] = reader.ReadUInt8();

        RealmID = reader.ReadUInt32();
        BuildType = reader.ReadInt8();

        Digest[17] = reader.ReadUInt8();
        Digest[6] = reader.ReadUInt8();
        Digest[0] = reader.ReadUInt8();
        Digest[1] = reader.ReadUInt8();
        Digest[11] = reader.ReadUInt8();

        LocalChallenge = reader.ReadUInt32();

        Digest[2] = reader.ReadUInt8();

        RegionID = reader.ReadUInt32();

        Digest[14] = reader.ReadUInt8();
        Digest[13] = reader.ReadUInt8();

        int compressedSize = reader.ReadInt32();
        if (compressedSize > 0xFFFF)
            throw new InvalidDataException("Addon Info buffer is too large");

        AddonInfo = ParseSecureAddons(reader.ReadBytes(compressedSize));

        UseIPv6 = reader.ReadBit() != 0;
        Account = reader.ReadString((int)reader.ReadBits(12));
    }

    private SecureAddonInfo[] ParseSecureAddons(ReadOnlyMemory<byte> addonPacket)
    {
        ClientPacketReader reader = new(new ReadOnlySequence<byte>(addonPacket));

        // Decompress the addon buffer
        int decompressedSize = reader.ReadInt32();
        byte[] decompressedPacket = new byte[decompressedSize];
        ZLib.InflateData(reader.ReadBytes((int)reader.UnreadBytes), decompressedPacket);

        reader = new(new ReadOnlySequence<byte>(decompressedPacket));

        int addonCount = reader.ReadInt32();
        if (addonCount > MaxSecureAddons)
            throw new InvalidDataException("Too many secure addons provided");

        SecureAddonInfo[] addons = new SecureAddonInfo[addonCount];

        for (int i = 0; i < addons.Length; i++)
        {
            addons[i] = new()
            {
                Name = reader.ReadCString(),
                KeyProvided = reader.ReadBool(),
                PublicKeyCrc = reader.ReadInt32(),
                UrlFileCrc = reader.ReadInt32()
            };
        }

        // @todo: use it lastBannedAddonTime
        reader.ReadTime();

        return addons;
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientAuthSession clientAuthSession = new(payload);

        // We don't allow auth session requests when the packet crypt has already been set up
        if (session.PacketCryptInitialized)
        {
            session.Close();
            return;
        }

        // Load game account data from database and initialize internal fields
        ResponseCodes loadResponse = await session.LoadGameAccountDataAsync(clientAuthSession.Account);
        if (loadResponse != ResponseCodes.AuthOk)
        {
            SendAuthResponseError(loadResponse, session);
            return;
        }

        // Initialize the packet crypt
        session.InitializePacketCrypt(true);

        // Check that Key and account name are the same on client and server
        uint t = 0;
        byte[] accountBytes = Encoding.UTF8.GetBytes(session.AccountName);

        using SHA1 sha = SHA1.Create();
        sha.TransformBlock(accountBytes, 0, accountBytes.Length, null, 0);
        sha.TransformBlock(BitConverter.GetBytes(t), 0, 4, null, 0);
        sha.TransformBlock(BitConverter.GetBytes(clientAuthSession.LocalChallenge), 0, 4, null, 0);
        sha.TransformBlock(session.AuthSeed, 0, session.AuthSeed.Length, null, 0);
        sha.TransformFinalBlock(session.SessionKey, 0, session.SessionKey.Length);

        byte[]? hash = sha.Hash;
        if (hash == null)
        {
            SendAuthResponseError(ResponseCodes.AuthReject, session);
            return;
        }

        if (!hash.SequenceEqual(clientAuthSession.Digest))
        {
            SendAuthResponseError(ResponseCodes.AuthFailed, session);
            return;
        }

        ServerAuthResponse response = new()
        {
            Result = ResponseCodes.AuthOk,
            SuccessInfo = new()
            {
                AccountExpansionLevel = session.AccountExpansionLevel,
                ActiveExpansionLevel = session.ActiveExpansionLevel
            }
        };

        session.EnqueuePacket(ref response);

        // After successful authentication we will also send addon info to the client
        SendAddonInfo(clientAuthSession.AddonInfo, session);

        ServerClientCacheVersion cacheVersion = new();
        session.EnqueuePacket(ref cacheVersion);

        ServerTutorialFlags serverTutorialFlags = new()
        {
            TutorialData = session.TutorialBits
        };

        session.EnqueuePacket(ref serverTutorialFlags);
    }

    private static void SendAuthResponseError(ResponseCodes error, GameSession session)
    {
        ServerAuthResponse serverAuthResponse = new()
        {
            Result = error
        };

        session.EnqueuePacket(ref serverAuthResponse);
    }

    private static void SendAddonInfo(ReadOnlySpan<SecureAddonInfo> secureAddons, GameSession session)
    {
        ServerAddonInfo addonInfo = new();
        foreach (SecureAddonInfo secureAddon in secureAddons)
        {
            addonInfo.Addons.Add(new AddonInfo()
            {
                Status = SecureAddonStatus.SecureHidden,
                InfoProvided = true
            });
        }

        session.EnqueuePacket(ref addonInfo);
    }
}
