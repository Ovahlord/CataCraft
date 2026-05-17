// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets.GruntPackets.SubStructures;

public struct ClientVersion
{
    public ClientVersion(byte majorVersion, byte minorVersion, byte bugfixVersion, ushort build)
    {
        MajorVersion = majorVersion;
        MinorVersion = minorVersion;
        BugfixVersion = bugfixVersion;
        Build = build;
    }

    public byte MajorVersion { get; private set; }
    public byte MinorVersion { get; private set; }
    public byte BugfixVersion { get; private set; }
    public ushort Build { get; private set; }

    public bool IsAcceptedClientBuild()
    {
        return MajorVersion == 4 && MinorVersion == 3 && BugfixVersion == 4 && Build == 15595;
    }

    public override string ToString()
    {
        return $"{MajorVersion}.{MinorVersion}.{BugfixVersion}.{Build}";
    }
}
