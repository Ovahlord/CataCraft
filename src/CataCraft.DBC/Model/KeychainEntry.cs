using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("KeyChain.db2")]
public sealed class KeychainEntry
{
    [Index(false)]
    public uint ID;
    [Cardinality(32)]
    public sbyte[] Key = new sbyte[32];
}
