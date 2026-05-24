using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LoadingScreens.dbc")]
public sealed class LoadingScreensEntry
{
    [Index(false)]
    public uint ID;
    public string Name = string.Empty;
    public string FileName = string.Empty;
    public int HasWideScreen;
}
