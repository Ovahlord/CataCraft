// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Cryptography;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Core.Server.Protocol.Packets.GruntPackets.SubStructures;
using CataCraft.Database.Login;
using CataCraft.Database.Login.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets;

public struct ClientAuthLogonProof
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
                    CdKeyProof =  reader.ReadBytes(20),
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

        ClientAuthLogonProof clientAuthLogonProof = new(payload);

        Console.WriteLine("Received logon proof");

        if (session.SRP6 == null)
        {
            SendAuthLogonProofError(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        if (!session.SRP6.VerifyChallengeResponse(clientAuthLogonProof.A, clientAuthLogonProof.ClientM, out byte[]? sessionKey))
        {
            Console.WriteLine("Authentication failed");
            SendAuthLogonProofError(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        await using LoginDbContext loginDb = new();
        GameAccount? gameAccount = await loginDb.GameAccounts
            .Include(ga => ga.Ban)
            .Include(ga => ga.Suspension)
            .Include(ga => ga.SessionData)
            .FirstOrDefaultAsync();

        // Make sure that the account exists
        if (gameAccount == null)
        {
            SendAuthLogonProofError(AuthResult.WowFailNoGameAccount, session);
            return;
        }

        // Check for a permanent ban
        if (gameAccount.Ban != null)
        {
            SendAuthLogonProofError(AuthResult.WowFailBanned, session);
            return;
        }

        // Check for temporary suspensions
        if (gameAccount.Suspension != null && gameAccount.Suspension.SuspensionExpirationTime > DateTime.UtcNow)
        {
            SendAuthLogonProofError(AuthResult.WowFailSuspended, session);
            return;
        }

        if (gameAccount.SessionData != null)
        {
            gameAccount.SessionData.SessionKey = sessionKey;
            gameAccount.SessionData.ClientLocale = (byte)session.Locale;
            await loginDb.SaveChangesAsync();
        }
        else
        {
            gameAccount.SessionData = new()
            {
                ClientLocale = (byte)session.Locale,
                SessionKey = sessionKey,
                GameAccount = gameAccount
            };
            await loginDb.SaveChangesAsync();
        }

        ServerAuthLogonProof authLogonProof = new()
        {
            Error = AuthResult.WowSuccess,
            M2 = SRP6.GetSessionVerifier(clientAuthLogonProof.A, clientAuthLogonProof.ClientM, sessionKey)
        };

        session.GruntAuthenticationState = GruntAuthenticationState.Authenticated;
        session.EnqueuePacket(ref authLogonProof);
    }

    private static void SendAuthLogonProofError(AuthResult error, GruntSession session)
    {
        ServerAuthLogonProof serverAuthLogonProof = new()
        {
            Error = error
        };

        session.EnqueuePacket(ref serverAuthLogonProof);
    }
}
