// This file is part of the CataCraft project, which is published under the MIT license.

using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;

namespace CataCraft.Core.Cryptography;

public sealed class ARC4
{
    private readonly RC4Engine _cypher = new();

    public void Init(byte[] seed)
    {
        KeyParameter key = new(seed);
        _cypher.Init(true, key);
    }
    public void UpdateData(Span<byte> data)
    {
        _cypher.ProcessBytes(data, data);
    }

}
