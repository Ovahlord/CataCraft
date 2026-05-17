// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public struct PlayerGuidLookupData
{
    public string Name { get; set; }
    public string RealmName { get; set; }
    public byte Race { get; set; }
    public byte Sex { get; set; }
    public byte ClassID { get; set; }
    public byte Level { get; set; }
    //Optional<DeclinedName> DeclinedNames;
}
