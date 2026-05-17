// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Game.World.Entities.Object;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientSetActiveMover
{
    public WowGuid MoverGUID { get; private set; }

    public ClientSetActiveMover(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);
        MoverGUID = new();
        MoverGUID[7] = reader.ReadBit();
        MoverGUID[2] = reader.ReadBit();
        MoverGUID[1] = reader.ReadBit();
        MoverGUID[0] = reader.ReadBit();
        MoverGUID[4] = reader.ReadBit();
        MoverGUID[5] = reader.ReadBit();
        MoverGUID[6] = reader.ReadBit();
        MoverGUID[3] = reader.ReadBit();

        reader.ReadByteSeq(MoverGUID, 3);
        reader.ReadByteSeq(MoverGUID, 2);
        reader.ReadByteSeq(MoverGUID, 4);
        reader.ReadByteSeq(MoverGUID, 0);
        reader.ReadByteSeq(MoverGUID, 5);
        reader.ReadByteSeq(MoverGUID, 1);
        reader.ReadByteSeq(MoverGUID, 6);
        reader.ReadByteSeq(MoverGUID, 7);
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientSetActiveMover setActiveMover = new(payload);
        return ValueTask.CompletedTask;
    }
}
