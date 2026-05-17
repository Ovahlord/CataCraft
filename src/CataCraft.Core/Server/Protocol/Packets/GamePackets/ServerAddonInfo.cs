// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets;

public ref struct ServerAddonInfo : IServerPacket
{
    public int Opcode => (int)GameServerOpcodes.SMSG_ADDON_INFO;

    public readonly List<AddonInfo> Addons = [];
    public readonly List<BannedAddonInfo> BannedAddons = [];

    public ServerAddonInfo()
    {
    }

    public void Serialize(out byte[] buffer, out int payloadLength)
    {
        ServerPacketWriter writer = new();

        // The amount of addons provided is sent in CMSG_AUTH_SESSION
        foreach (AddonInfo addon in Addons)
        {
            writer.WriteUInt8((byte)addon.Status);
            writer.WriteBool(addon.InfoProvided);
            if (addon.InfoProvided)
            {
                writer.WriteBool(addon.KeyProvided);
                if (addon.KeyProvided)
                    writer.WriteBytes(addon.KeyData);

                writer.WriteInt32(addon.Revision);
            }

            writer.WriteBool(addon.UrlProvided);
            if (addon.UrlProvided)
                writer.WriteCString(addon.Url);
        }

        writer.WriteInt32(BannedAddons.Count);

        foreach (BannedAddonInfo bannedAddon in BannedAddons)
        {
            writer.WriteInt32(bannedAddon.Id);
            writer.WriteBytes(bannedAddon.NameMD5);
            writer.WriteBytes(bannedAddon.VersionMD5);
            writer.WriteTime(bannedAddon.LastModified);
            writer.WriteInt32(bannedAddon.Flags);
        }

        buffer = writer.Buffer;
        payloadLength = writer.WrittenBytes;
    }
}
