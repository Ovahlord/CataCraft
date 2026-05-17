// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public class SecureAddonInfo
{
    public string Name { get; set; } = string.Empty;
    public bool KeyProvided { get; set; }
    public int PublicKeyCrc { get; set; }
    public int UrlFileCrc { get; set; }
}
