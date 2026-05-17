// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Game.Server.Protocol.Packets.GruntPackets.SubStructures;

public sealed class AuthWaitInfo
{
    public uint WaitCount { get; set; }
    public bool HasFCM { get; set; }
}
