// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Server.Protocol.Packets;
using CataCraft.Database.Realm.Model;
using CataCraft.Game.Enums;

namespace CataCraft.Game.Server.Protocol.Packets.GamePackets;

public ref struct ServerAccountDataTimes : IServerPacket
{
    private const int PerCharacterCacheMask = 0x02 | 0x08 | 0x20 | 0x80;

    public int Opcode => (int)GameServerOpcodes.SMSG_ACCOUNT_DATA_TIMES;

    public DateTimeOffset ServerTime { get; set; }
    public int Mask { get; set; }
    public List<DateTimeOffset> AccountTimes { get; set; } = [];

    public ServerAccountDataTimes()
    {
    }

    public ServerAccountDataTimes(ICollection<CharacterData>? characterAccountData)
    {
        ServerTime = DateTimeOffset.Now;
        Mask = PerCharacterCacheMask;

        // If the character has no cached db data yet, we just send unix epoch for all data types
        if (characterAccountData == null)
        {
            for (int i = 0; i < (int)AccountDataType.Max; ++i)
            {
                if ((PerCharacterCacheMask & (1 << i)) != 0)
                    AccountTimes.Add(DateTimeOffset.UnixEpoch);
            }
        }
        else
        {
            // Otherwise we send whatever is needed
            Dictionary<int, DateTimeOffset> gameAccountData = characterAccountData
                .Select(gad => new { gad.Id, gad.Time })
                .ToDictionary(k => k.Id, v => v.Time);

            // Sanitize the result to make sure we send the expected amount of times
            for (int i = 0; i < (int)AccountDataType.Max; ++i)
            {
                if ((PerCharacterCacheMask & (1 << i)) == 0)
                {
                    gameAccountData.Remove(i);
                    continue;
                }

                gameAccountData.TryAdd(i, DateTimeOffset.UnixEpoch);
            }

            AccountTimes = gameAccountData
                .OrderBy(gad => gad.Key)
                .Select(gad => gad.Value)
                .ToList();
        }

    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteTime(ServerTime);
        writer.WriteUInt8(1);
        writer.WriteInt32(Mask);

        foreach (DateTimeOffset accountTime in AccountTimes)
            writer.WriteTime(accountTime);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
