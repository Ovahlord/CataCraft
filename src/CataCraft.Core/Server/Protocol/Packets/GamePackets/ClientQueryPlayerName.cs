// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Enums;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientQueryPlayerName
{
    public WowGuid Player { get; private set; }

    public ClientQueryPlayerName(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        Player = reader.ReadUInt64();
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientQueryPlayerName queryPlayerName = new(payload);

        ServerQueryPlayerNameResponse playerNameResponse = new()
        {
            Player = queryPlayerName.Player,
            Result = 0,
            Data = new()
            {
                Name = "Test",
                RealmName = string.Empty,
                ClassID = 11,
                Level = 1,
                Race = (byte)ChrRace.Nightelf
            }
        };

        session.EnqueuePacket(ref playerNameResponse);

        return ValueTask.CompletedTask;
    }
}
