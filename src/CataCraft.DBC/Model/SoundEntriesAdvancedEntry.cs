using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("SoundEntriesAdvanced.dbc")]
public sealed class SoundEntriesAdvancedEntry
{
    [Index(false)]
    public uint ID;
    public int SoundEntryID;
    public float InnerRadius2D;
    public int TimeA;
    public int TimeB;
    public int TimeC;
    public int TimeD;
    public int RandomOffsetRange;
    public int Usage;
    public int TimeIntervalMin;
    public int TimeIntervalMax;
    public int VolumeSliderCategory;
    public float DuckToSFX;
    public float DuckToMusic;
    public float DuckToAmbience;
    public float InnerRadiusOfInfluence;
    public float OuterRadiusOfInfluence;
    public int TimeToDuck;
    public int TimeToUnduck;
    public float InsideAngle;
    public float OutsideAngle;
    public float OutsideVolume;
    public float OuterRadius2D;
    public int MinRandomPosOffset;
    public int MaxRandomPosOffset;
    public float Unknown432;
}
