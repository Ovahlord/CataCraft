using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellCastingRequirements.dbc")]
public sealed class SpellCastingRequirementsEntry
{
    [Index(false)]
    public uint ID;
    public int FacingCasterFlags;
    public int MinFactionID;
    public int MinReputation;
    public int RequiredAreasID;
    public int RequiredAuraVision;
    public int RequiresSpellFocus;
}
