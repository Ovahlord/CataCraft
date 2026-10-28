using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MountCapability.dbc")]
public sealed class MountCapabilityEntry
{
    [Index(true)]
    public uint ID;
    public int Flags;
    public int ReqRidingSkill;
    public int ReqAreaID;
    public int ReqSpellAuraID;
    public int ReqSpellKnownID;
    public int ModSpellAuraID;
    public int ReqMapID;
}
