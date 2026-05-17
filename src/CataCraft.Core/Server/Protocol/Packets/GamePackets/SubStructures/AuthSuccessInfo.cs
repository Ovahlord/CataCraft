// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public sealed class AuthSuccessInfo
{
    public uint TimeRemain { get; set; }
    public uint TimeRested { get; set; }
    public uint TimeSecondsUntilPCKick { get; set; }
    public byte AccountExpansionLevel { get; set; }
    public byte ActiveExpansionLevel { get; set; }
    public byte TimeOptions { get; set; }
}
