// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public class BannedAddonInfo
{
    public int Id { get; set; }
    public byte[] NameMD5 { get; set; } = [];
    public byte[] VersionMD5 { get; set; } = [];
    public DateTimeOffset LastModified { get; set; }
    public int Flags { get; set; }
}
