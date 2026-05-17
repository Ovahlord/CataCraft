using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("PhaseXPhaseGroup.dbc")]
public sealed class PhaseXPhaseGroupEntry
{
    [Index(true)]
    public uint ID;
    public int PhaseID;
    public int PhaseGroupID;
}
