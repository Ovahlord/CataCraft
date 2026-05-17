// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.Net;
using CataCraft.Core.Cryptography;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.Server.Protocol.Packets.GruntPackets.SubStructures;

namespace CataCraft.Game.Server.Protocol.Packets.GruntPackets;

public ref struct ClientAuthLogonChallenge
{
    private const string AcceptedGameName = "\0WoW";
    private const string AcceptedPlatformName = "\0x86";
    private const string AcceptedOsName = "\0Win";
    private const int MaxAccountNameLength = 16;
    private const byte LastGruntProtocolVersion = 8;

    public byte ProtocolVersion { get; private set; }
    public ushort Size { get; private set; }
    public string GameName { get; private set; }
    public ClientVersion Version { get; private set; }
    public string Platform { get; private set; }
    public string OS { get; private set; }
    public string Locale { get; private set; }
    public uint TimeZoneBias { get; private set; }
    public IPAddress IP { get; private set; }
    public string Login { get; private set; } = string.Empty;

    private ClientAuthLogonChallenge(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        ProtocolVersion = reader.ReadUInt8();
        Size = reader.ReadUInt16();
        GameName = reader.ReadFourCCString();
        Version = new(reader.ReadUInt8(), reader.ReadUInt8(), reader.ReadUInt8(), reader.ReadUInt16());
        Platform = reader.ReadFourCCString();
        OS = reader.ReadFourCCString();
        Locale = reader.ReadFourCCString();
        TimeZoneBias = reader.ReadUInt32();
        IP = new IPAddress(reader.ReadInt32());
        Login = reader.ReadString(reader.ReadUInt8());
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GruntSession session)
    {
        // Only accept logon challenge packets when we have entered the proof stage
        if (session.GruntAuthenticationState != GruntAuthenticationState.LogonChallenge)
        {
            session.Close();
            return;
        }

        GruntPackets.ClientAuthLogonChallenge clientAuthLogonChallenge = new(in payload);

        // Validate protocol, client version and platform
        if (!ValidateGameVersion(clientAuthLogonChallenge))
        {
            SendAuthLogonChallengeErrorAndCloseSession(AuthResult.WowFailVersionInvalid, session);
            return;
        }

        // Validate account name length
        if (clientAuthLogonChallenge.Login.Length > MaxAccountNameLength)
        {
            SendAuthLogonChallengeErrorAndCloseSession(AuthResult.WowFailUnknownAccount, session);
            return;
        }

        // Validate locale
        if (string.IsNullOrWhiteSpace(clientAuthLogonChallenge.Locale) ||
            !Enum.TryParse(clientAuthLogonChallenge.Locale, true, out ClientLocale locale))
        {
            SendAuthLogonChallengeErrorAndCloseSession(AuthResult.WowFailVersionInvalid, session);
            return;
        }

        session.AccountName = clientAuthLogonChallenge.Login;
        session.Locale = locale;

        // Load account data from db and initialize the key exchange data
        if (!await session.LoadGameAccountDataAsync())
        {
            SendAuthLogonChallengeErrorAndCloseSession(AuthResult.WowFailUnknownAccount, session);
            return;
        }

        if (session.SRP6 == null)
        {
            SendAuthLogonChallengeErrorAndCloseSession(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        ServerAuthLogonChallenge authLogonChallenge = new()
        {
            Error = AuthResult.WowSuccess,
            B = session.SRP6.B,
            G = SRP6.g,
            N = SRP6.N,
            S = session.SRP6.s
        };

        session.GruntAuthenticationState = GruntAuthenticationState.LogonProof;
        session.EnqueuePacket(ref authLogonChallenge);
    }

    private static void SendAuthLogonChallengeErrorAndCloseSession(AuthResult result, GruntSession session)
    {
        ServerAuthLogonChallenge authLogonChallenge = new(result);
        session.EnqueuePacket(ref authLogonChallenge, true);
    }

    private static bool ValidateGameVersion(in ClientAuthLogonChallenge clientAuthLogonChallenge)
    {
        // Validate the Grunt protocol version
        if (clientAuthLogonChallenge.ProtocolVersion != LastGruntProtocolVersion)
            return false;

        // Validate the client build
        if (!clientAuthLogonChallenge.Version.IsAcceptedClientBuild())
            return false;

        // Validate provided platform and locale settings
        if (!clientAuthLogonChallenge.GameName.Equals(AcceptedGameName)
            || !clientAuthLogonChallenge.Platform.Equals(AcceptedPlatformName)
            || !clientAuthLogonChallenge.OS.Equals(AcceptedOsName))
            return false;

        return true;
    }

}
