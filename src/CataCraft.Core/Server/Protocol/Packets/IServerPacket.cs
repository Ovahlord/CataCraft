// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Server.Protocol.Packets;

public interface IServerPacket
{
    public int Opcode { get; }
    public void Serialize(out byte[] buffer, out int payloadLength);
}
