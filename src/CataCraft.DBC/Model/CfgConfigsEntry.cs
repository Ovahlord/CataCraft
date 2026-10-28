using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Cfg_Configs.dbc")]
public sealed class CfgConfigsEntry
{
    [Index(true)]
    public uint ID;
    public int RealmType;
    public int PlayerKillingAllowed;
    public int Roleplaying;
    public int PlayerAttackSpeedBase;
}
