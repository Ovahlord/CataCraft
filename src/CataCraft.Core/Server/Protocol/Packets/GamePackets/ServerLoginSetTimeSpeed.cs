// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerLoginSetTimeSpeed : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_LOGIN_SET_TIME_SPEED;

    public float NewSpeed { get; set; } = 0.01666667f;
    public uint GameTime { get; set; }
    public uint GameTimeHolidayOffset { get; set; }

    public ServerLoginSetTimeSpeed()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt32(GameTime);
        writer.WriteFloat(NewSpeed);
        writer.WriteUInt32(GameTimeHolidayOffset);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
