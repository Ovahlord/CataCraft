// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerLoadCUFProfiles : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_LOAD_CUF_PROFILES;

    public readonly List<CUFProfile> Profiles { get; } = [];

    public ServerLoadCUFProfiles()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteBits(Profiles.Count, 20);

        foreach (CUFProfile profile in Profiles)
        {
            writer.WriteBit(false); // unk
            writer.WriteBit(profile.AutoActivate10Players);
            writer.WriteBit(profile.AutoActivate5Players);
            writer.WriteBit(profile.AutoActivate25Players);
            writer.WriteBit(profile.DisplayHealPrediction);
            writer.WriteBit(profile.AutoActivatePvE);
            writer.WriteBit(profile.HorizontalGroups);
            writer.WriteBit(profile.AutoActivate40Players);
            writer.WriteBit(profile.AutoActivate3Players);
            writer.WriteBit(profile.DisplayAggroHighlight);
            writer.WriteBit(profile.DisplayBorder);
            writer.WriteBit(profile.AutoActivate2Players);
            writer.WriteBit(profile.DisplayNonBossDebuffs);
            writer.WriteBit(profile.DisplayMainTankAndAssist);
            writer.WriteBit(false); // unk
            writer.WriteBit(profile.AutoActivateSpec2);
            writer.WriteBit(profile.UseClassColors);
            writer.WriteBit(profile.DisplayPowerBar);
            writer.WriteBit(profile.AutoActivateSpec1);
            writer.WriteBits(profile.Name.Length, 8);
            writer.WriteBit(profile.DisplayOnlyDispellableDebuffs);
            writer.WriteBit(profile.KeepGroupsTogether);
            writer.WriteBit(false); // unk
            writer.WriteBit(profile.AutoActivate15Players);
            writer.WriteBit(profile.DisplayPets);
            writer.WriteBit(profile.AutoActivatePvP);
        }

        writer.FlushBits();

        foreach (CUFProfile profile in Profiles)
        {
            writer.WriteUInt16(0); // unk
            writer.WriteUInt16(profile.FrameHeight);
            writer.WriteUInt16(0); // unk
            writer.WriteUInt8(0); // unk
            writer.WriteUInt16(0); // unk
            writer.WriteUInt8(0); // unk
            writer.WriteUInt8(profile.HealthText);
            writer.WriteUInt8(profile.SortBy);
            writer.WriteUInt16(profile.FrameWidth);
            writer.WriteUInt8(0); // unk
            writer.WriteString(profile.Name);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
