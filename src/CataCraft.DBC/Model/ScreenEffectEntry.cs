using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("ScreenEffect.dbc")]
public sealed class ScreenEffectEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public int Effect;
    [Cardinality(4)]
    public int[] Param = new int[4];
    public int LightParamsID;
    public int SoundAmbienceID;
    public int ZoneMusicID;
    public int TimeOfDayOverride;
}
