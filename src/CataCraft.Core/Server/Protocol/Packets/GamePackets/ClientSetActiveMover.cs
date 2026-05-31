// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using CataCraft.Core.Game.Entities.Object;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ClientSetActiveMover
{
    public WowGuid MoverGUID { get; private set; }

    public ClientSetActiveMover(ReadOnlySequence<byte> payload)
    {
        ClientPacketReader reader = new(payload);

        WowGuid moverGuid = MoverGUID;
        moverGuid[7] = reader.ReadBit();
        moverGuid[2] = reader.ReadBit();
        moverGuid[1] = reader.ReadBit();
        moverGuid[0] = reader.ReadBit();
        moverGuid[4] = reader.ReadBit();
        moverGuid[5] = reader.ReadBit();
        moverGuid[6] = reader.ReadBit();
        moverGuid[3] = reader.ReadBit();

        reader.ReadByteSeq(ref moverGuid, 3);
        reader.ReadByteSeq(ref moverGuid, 2);
        reader.ReadByteSeq(ref moverGuid, 4);
        reader.ReadByteSeq(ref moverGuid, 0);
        reader.ReadByteSeq(ref moverGuid, 5);
        reader.ReadByteSeq(ref moverGuid, 1);
        reader.ReadByteSeq(ref moverGuid, 6);
        reader.ReadByteSeq(ref moverGuid, 7);

        MoverGUID = moverGuid;
    }

    public static ValueTask HandlePacket(ReadOnlySequence<byte> payload, GameSession session)
    {
        ClientSetActiveMover setActiveMover = new(payload);
        return ValueTask.CompletedTask;
    }
}
