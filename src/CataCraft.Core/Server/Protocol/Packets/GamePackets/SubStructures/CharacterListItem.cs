// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public sealed class CharacterListItem
{
    public uint DisplayID { get; set; }
    public uint DisplayEnchantID { get; set; }
    public byte InvType { get; set; }
}
