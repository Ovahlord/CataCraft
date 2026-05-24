// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;
using CataCraft.Database.Login;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientReadyForAccountDataTimes
{
    private const int GlobalCacheMask = 0x01 | 0x04 | 0x10;

    public ClientReadyForAccountDataTimes(ReadOnlySequence<byte> _)
    {
    }

    public static async ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        await using LoginDbContext loginDb = new();
        var gameAccountData = await loginDb.GameAccountDataEntries
            .Where(gad => gad.GameAccountId == session.GameAccountId)
            .Select(gad => new { gad.Id, gad.Time }).ToDictionaryAsync(k => k.Id, v => v.Time);

        // Sanitize the result to make sure we send the expected amount of times
        for (int i = 0; i < (int)AccountDataType.Max; ++i)
        {
            if ((GlobalCacheMask & (1 << i)) == 0)
            {
                gameAccountData.Remove(i);
                continue;
            }

            gameAccountData.TryAdd(i, DateTimeOffset.UnixEpoch);
        }

        ServerAccountDataTimes accountDataTimes = new()
        {
            ServerTime = DateTimeOffset.Now,
            Mask = GlobalCacheMask,
            AccountTimes = gameAccountData
                .OrderBy(gad => gad.Key)
                .Select(gad => gad.Value)
                .ToArray()
        };

        session.EnqueuePacket(ref accountDataTimes);
    }
}
