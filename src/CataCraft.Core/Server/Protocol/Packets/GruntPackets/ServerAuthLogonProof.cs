// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Server.Networking;

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets;

public ref struct ServerAuthLogonProof : IServerPacket
{
    public int Opcode => (int)GruntOpcodes.AuthLogonProof;

    public AuthResult Error { get; set; }
    public byte[] M2 { get; set; } = [];
    public GameAccountFlags AccountFlags { get; set; }
    public uint HardwareSurveyId { get; set; }
    public ushort Unknown { get; set; }

    public ServerAuthLogonProof()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt8((byte)Error);
        if (Error != AuthResult.WowSuccess)
        {
            writer.WriteUInt16(0);
        }
        else
        {
            writer.WriteBytes(M2);
            writer.WriteUInt32((uint)AccountFlags);
            writer.WriteUInt32(HardwareSurveyId);
            writer.WriteUInt16(Unknown);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
