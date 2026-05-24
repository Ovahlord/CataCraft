using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("DestructibleModelData.dbc")]
public sealed class DestructibleModelDataEntry
{
    [Index(false)]
    public uint ID;
    public int State0WMO;
    public int State0ImpactEffectDoodadSet;
    public int State0AmbientDoodadSet;
    public int State0NameSet;
    public int State1WMO;
    public int State1DestructionDoodadSet;
    public int State1ImpactEffectDoodadSet;
    public int State1AmbientDoodadSet;
    public int State1NameSet;
    public int State2WMO;
    public int State2DestructionDoodadSet;
    public int State2ImpactEffectDoodadSet;
    public int State2AmbientDoodadSet;
    public int State2NameSet;
    public int State3WMO;
    public int State3InitDoodadSet;
    public int State3AmbientDoodadSet;
    public int State3NameSet;
    public int EjectDirection;
    public int RepairGroundFx;
    public int DoNotHighlight;
    public int HealEffect;
    public int HealEffectSpeed;
}
