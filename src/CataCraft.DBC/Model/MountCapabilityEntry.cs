using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MountCapability.dbc")]
public sealed class MountCapabilityEntry
{
    [Index(false)]
    public uint ID;
    public int Flags;
    public int ReqRidingSkill;
    public int ReqAreaID;
    public int ReqSpellAuraID;
    public int ReqSpellKnownID;
    public int ModSpellAuraID;
    public int ReqMapID;
}
