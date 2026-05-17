// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerFeatureSystemStatus : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_FEATURE_SYSTEM_STATUS;

    public uint ScrollOfResurrectionMaxRequestsPerDay { get; set; }
    public uint ScrollOfResurrectionRequestsRemaining { get; set; }
    public uint CfgRealmID { get; set; }
    public uint CfgRealmRecID { get; set; }
    public byte ComplaintStatus { get; set; }
    public bool ScrollOfResurrectionEnabled { get; set; }
    public bool VoiceEnabled { get; set; }
    public bool ItemRestorationButtonEnabled { get; set; }
    public bool TravelPassEnabled { get; set; }

    public ServerFeatureSystemStatus()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteUInt8(ComplaintStatus);
        writer.WriteUInt32(ScrollOfResurrectionRequestsRemaining);
        writer.WriteUInt32(ScrollOfResurrectionMaxRequestsPerDay);
        writer.WriteUInt32(CfgRealmID);
        writer.WriteUInt32(CfgRealmRecID);
        writer.WriteBit(ItemRestorationButtonEnabled);
        writer.WriteBit(TravelPassEnabled);
        writer.WriteBit(ScrollOfResurrectionEnabled);
        writer.WriteBit(false);
        writer.WriteBit(false);
        writer.WriteBit(VoiceEnabled);
        writer.FlushBits();

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
