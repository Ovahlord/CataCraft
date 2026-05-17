// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerAuthResponse : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_AUTH_RESPONSE;

    public AuthSuccessInfo? SuccessInfo { get; set; }
    public AuthWaitInfo? WaitInfo { get; set; }
    public ResponseCodes Result { get; set; }

    public ServerAuthResponse()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteBit(WaitInfo != null);

        if (WaitInfo != null)
            writer.WriteBit(WaitInfo.HasFCM);

        writer.WriteBit(SuccessInfo != null);
        writer.FlushBits();

        if (SuccessInfo != null)
        {
            writer.WriteUInt32(SuccessInfo.TimeRemain);
            writer.WriteUInt8(SuccessInfo.ActiveExpansionLevel);
            writer.WriteUInt32(SuccessInfo.TimeSecondsUntilPCKick);
            writer.WriteUInt8(SuccessInfo.AccountExpansionLevel);
            writer.WriteUInt32(SuccessInfo.TimeRested);
            writer.WriteUInt8(SuccessInfo.TimeOptions);
        }

        writer.WriteUInt8((byte)Result);

        if (WaitInfo != null)
            writer.WriteUInt32(WaitInfo.WaitCount);

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
