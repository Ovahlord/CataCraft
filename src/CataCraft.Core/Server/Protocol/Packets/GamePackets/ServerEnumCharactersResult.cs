// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerEnumCharactersResult : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_ENUM_CHARACTERS_RESULT;

    public bool Success { get; set; }
    public List<CharacterListEntry> Characters { get; set; } = [];
    public List<RestrictedFactionChangeRule> FactionChangeRestrictions { get; set; } = [];

    public ServerEnumCharactersResult()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        writer.WriteBits((ulong)FactionChangeRestrictions.Count, 23);
        writer.WriteBit(Success);
        writer.WriteBits((ulong)Characters.Count, 17);

        foreach (CharacterListEntry character in Characters)
        {
            writer.WriteBit(character.Guid[3] != 0);
            writer.WriteBit(character.GuildGUID[1] != 0);
            writer.WriteBit(character.GuildGUID[7] != 0);
            writer.WriteBit(character.GuildGUID[2] != 0);
            writer.WriteBits((uint)character.Name.Length, 7);
            writer.WriteBit(character.Guid[4] != 0);
            writer.WriteBit(character.Guid[7] != 0);
            writer.WriteBit(character.GuildGUID[3] != 0);
            writer.WriteBit(character.Guid[5] != 0);
            writer.WriteBit(character.GuildGUID[6] != 0);
            writer.WriteBit(character.Guid[1] != 0);
            writer.WriteBit(character.GuildGUID[5] != 0);
            writer.WriteBit(character.GuildGUID[4] != 0);
            writer.WriteBit(character.FirstLogin);
            writer.WriteBit(character.Guid[0] != 0);
            writer.WriteBit(character.Guid[2] != 0);
            writer.WriteBit(character.Guid[6] != 0);
            writer.WriteBit(character.GuildGUID[0] != 0);
        }

        writer.FlushBits();

        foreach (CharacterListEntry character in Characters)
        {
            writer.WriteUInt8(character.ClassID);

            foreach (CharacterListItem? characterItem in character.InventoryItems)
            {
                if (characterItem == null)
                {
                    writer.WriteUInt8(0);
                    writer.WriteUInt32(0);
                    writer.WriteUInt32(0);
                }
                else
                {
                    writer.WriteUInt8(characterItem.InvType);
                    writer.WriteUInt32(characterItem.DisplayID);
                    writer.WriteUInt32(characterItem.DisplayEnchantID);
                }
            }

            writer.WriteUInt32(character.PetCreatureFamilyID);
            writer.WriteByteSeq(character.GuildGUID[2]);
            writer.WriteUInt8(character.ListPosition);
            writer.WriteUInt8(character.HairStyle);
            writer.WriteByteSeq(character.GuildGUID[3]);
            writer.WriteUInt32(character.PetCreatureDisplayID);
            writer.WriteInt32((int)character.Flags);
            writer.WriteUInt8(character.HairColor);
            writer.WriteByteSeq(character.Guid[4]);
            writer.WriteInt32(character.MapID);
            writer.WriteByteSeq(character.GuildGUID[5]);
            writer.WriteFloat(character.PreloadPos[2]);
            writer.WriteByteSeq(character.GuildGUID[6]);
            writer.WriteUInt32(character.PetExperienceLevel);
            writer.WriteByteSeq(character.Guid[3]);
            writer.WriteFloat(character.PreloadPos[1]);
            writer.WriteInt32((int)character.Flags2);
            writer.WriteUInt8(character.FacialHair);
            writer.WriteByteSeq(character.Guid[7]);
            writer.WriteUInt8(character.SexID);
            writer.WriteString(character.Name); // validate if correct method
            writer.WriteUInt8(character.FaceID);
            writer.WriteByteSeq(character.Guid[0]);
            writer.WriteByteSeq(character.Guid[2]);
            writer.WriteByteSeq(character.GuildGUID[1]);
            writer.WriteByteSeq(character.GuildGUID[7]);
            writer.WriteFloat(character.PreloadPos[0]);
            writer.WriteUInt8(character.SkinID);
            writer.WriteUInt8(character.RaceID);
            writer.WriteUInt8(character.ExperienceLevel);
            writer.WriteByteSeq(character.Guid[6]);
            writer.WriteByteSeq(character.GuildGUID[4]);
            writer.WriteByteSeq(character.GuildGUID[0]);
            writer.WriteByteSeq(character.Guid[5]);
            writer.WriteByteSeq(character.Guid[1]);
            writer.WriteInt32(character.ZoneID);
        }

        foreach (RestrictedFactionChangeRule factionChangeRule in FactionChangeRestrictions)
        {
            writer.WriteInt32(factionChangeRule.Mask);
            writer.WriteUInt8(factionChangeRule.RaceID);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
