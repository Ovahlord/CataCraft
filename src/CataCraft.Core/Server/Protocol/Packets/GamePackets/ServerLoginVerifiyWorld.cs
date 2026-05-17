// This file is part of the CataCraft project, which is published under the MIT license.

using System.Numerics;
using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerLoginVerifiyWorld : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_LOGIN_VERIFY_WORLD;

    public Vector3 Position { get; set; }
    public float Facing  { get; set; }
    public int MapID { get; set; }

    public ServerLoginVerifiyWorld()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteFloat(Position.X);
        writer.WriteFloat(Position.Y);
        writer.WriteFloat(Position.Z);
        writer.WriteFloat(Facing);
        writer.WriteInt32(MapID);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
