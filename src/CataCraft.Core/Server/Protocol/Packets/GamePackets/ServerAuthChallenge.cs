// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerAuthChallenge : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_AUTH_CHALLENGE;

    public uint[] DosChallenge { get; set; } = [];
    public uint Challenge { get; set; }
    public byte DosZeroBits { get; set; }

    public ServerAuthChallenge()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        foreach (uint dosChallenge in DosChallenge)
        {
            writer.WriteUInt32(dosChallenge);
        }

        writer.WriteUInt32(Challenge);
        writer.WriteUInt8(DosZeroBits);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
