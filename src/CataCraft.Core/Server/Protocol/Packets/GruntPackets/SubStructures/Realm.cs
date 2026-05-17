// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets.SubStructures;

public class Realm
{
    public RealmType Type { get; set; }
    public bool Locked { get; set; }
    public RealmFlags Flags { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public float Population { get; set; }
    public byte NumCharacters  { get; set; }
    public byte RealmCategory { get; set; }
    public byte RealmId { get; set; }
}
