// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Cryptography;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using CataCraft.Game.Enums;
using CataCraft.Game.Server.Networking;
using CataCraft.Game.Server.Protocol.Packets.GruntPackets.SubStructures;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Game.Server.Protocol.Packets.GruntPackets;

public ref struct ClientAuthLogonProof
{
    public byte[] A { get; private set; }
    public byte[] ClientM { get; private set; }
    public byte[] CrcHash { get; private set; }
    public TelemetryKey[] TelemetryKeys { get; private set; } = [];
    public SecurityFlags SecurityFlag { get; private set; }

    private ClientAuthLogonProof(in ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        A = reader.ReadBytes(32);
        ClientM = reader.ReadBytes(20);
        CrcHash = reader.ReadBytes(20);
        byte telemetryCount = reader.ReadUInt8();
        if (telemetryCount > 0)
        {
            TelemetryKeys = new TelemetryKey[telemetryCount];
            for (int i = 0; i < TelemetryKeys.Length; i++)
            {
                TelemetryKeys[i] = new()
                {
                    Unknown1 = reader.ReadUInt16(),
                    Unknown2 = reader.ReadUInt32(),
                    Unknown3 = reader.ReadBytes(4),
                    CdKeyProof = reader.ReadBytes(20),
                };
            }
        }

        SecurityFlag = (SecurityFlags)reader.ReadUInt8();
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GruntSession session)
    {
        // Only accept logon proof packets when we have entered the proof stage
        if (session.GruntAuthenticationState != GruntAuthenticationState.LogonProof)
        {
            session.Close();
            return;
        }

        // Make sure that the account exists
        if (session.GameAccountId == 0)
        {
            SendAuthLogonProofErrorAndCloseSession(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        ClientAuthLogonProof clientAuthLogonProof = new(payload);
        byte[] a = clientAuthLogonProof.A;
        byte[] clientM = clientAuthLogonProof.ClientM;

        // Vaidate the challenge response
        if (session.SRP6 == null || !session.SRP6.VerifyChallengeResponse(clientAuthLogonProof.A, clientAuthLogonProof.ClientM, out byte[]? sessionKey))
        {
            SendAuthLogonProofErrorAndCloseSession(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        await using LoginDbContext loginDb = new();
        GameAccount? gameAccount = await loginDb.GameAccounts
            .Include(ga => ga.Ban)
            .Include(ga => ga.Suspension)
            .Include(ga => ga.SessionData)
            .FirstOrDefaultAsync(g => g.Id == session.GameAccountId);

        if (gameAccount == null)
        {
            SendAuthLogonProofErrorAndCloseSession(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        // Check for a permanent ban
        if (gameAccount.Ban != null)
        {
            SendAuthLogonProofErrorAndCloseSession(AuthResult.WowFailBanned, session);
            return;
        }

        // Check for temporary suspensions
        if (gameAccount.Suspension != null && gameAccount.Suspension.SuspensionExpirationTime > DateTime.UtcNow)
        {
            SendAuthLogonProofErrorAndCloseSession(AuthResult.WowFailSuspended, session);
            return;
        }

        // Store the new generated session key and current locate
        AddOrUpdateSessionData(session, gameAccount, sessionKey);
        await loginDb.SaveChangesAsync();

        ServerAuthLogonProof authLogonProof = new()
        {
            Error = AuthResult.WowSuccess,
            M2 = SRP6.GetSessionVerifier(a, clientM, sessionKey)
        };

        session.GruntAuthenticationState = GruntAuthenticationState.Authenticated;
        session.EnqueuePacket(ref authLogonProof);
    }

    private static void SendAuthLogonProofErrorAndCloseSession(AuthResult error, GruntSession session)
    {
        ServerAuthLogonProof serverAuthLogonProof = new(error);
        session.EnqueuePacket(ref serverAuthLogonProof, true);
    }

    private static void AddOrUpdateSessionData(GruntSession session, GameAccount gameAccount, byte[] sessionKey)
    {
        if (gameAccount.SessionData != null)
        {
            gameAccount.SessionData.SessionKey = sessionKey;
            gameAccount.SessionData.ClientLocale = (byte)session.Locale;
        }
        else
        {
            gameAccount.SessionData = new GameAccountSessionData()
            {
                ClientLocale = (byte)session.Locale,
                SessionKey = sessionKey,
                GameAccount = gameAccount
            };
        }
    }
}
