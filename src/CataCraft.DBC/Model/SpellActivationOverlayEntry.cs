using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SpellActivationOverlay.dbc")]
public sealed class SpellActivationOverlayEntry
{
    [Index(false)]
    public uint ID;
    public int SpellID;
    public int OverlayFileDataID;
    public int ScreenLocationID;
    public int Color;
    public float Scale;
    [Cardinality(3)]
    public int[] IconHighlightSpellClassMask = new int[3];
    public int TriggerType;
    public int SoundEntriesID;
}
