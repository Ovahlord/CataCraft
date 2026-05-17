// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public sealed class AuthWaitInfo
{
    public uint WaitCount { get; set; }
    public bool HasFCM { get; set; }
}
