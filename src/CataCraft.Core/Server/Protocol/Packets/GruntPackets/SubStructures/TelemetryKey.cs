// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets.SubStructures;

public class TelemetryKey
{
    public ushort Unknown1 { get; set; }
    public uint Unknown2 { get; set; }
    public byte[] Unknown3 { get; set; } = [];
    public byte[] CdKeyProof { get; set; } = [];
}
