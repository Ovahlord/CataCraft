// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Enums;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public class AddonInfo
{
    public SecureAddonStatus Status { get; set; }
    public bool InfoProvided { get; set; }
    public bool KeyProvided { get; set; }
    public byte[] KeyData { get; set; } = [];
    public int Revision { get; set; }
    public bool UrlProvided { get; set; }
    public string Url { get; set; } = string.Empty;
}
