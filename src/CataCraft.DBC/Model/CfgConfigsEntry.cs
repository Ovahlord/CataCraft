using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("Cfg_Configs.dbc")]
public sealed class CfgConfigsEntry
{
    [Index(false)]
    public uint ID;
    public int RealmType;
    public int PlayerKillingAllowed;
    public int Roleplaying;
    public int PlayerAttackSpeedBase;
}
