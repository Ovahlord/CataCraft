// This file is part of the CataCraft project, which is published under the MIT license.

using System.Net;

namespace CataCraft.Core.Server.Protocol.Packets.GamePackets.SubStructures;

public struct ConnectToPayload
{
    public ConnectToPayload(IPEndPoint where)
    {
        Where = where;
    }

    public IPEndPoint Where { get; private set; }
    public uint Adler32 => 0xA0A66C10;
    public byte XorMagic => 0x2A;
}
