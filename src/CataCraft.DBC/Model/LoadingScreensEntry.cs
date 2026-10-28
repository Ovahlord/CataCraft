using CataCraft.DBC.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("LoadingScreens.dbc")]
public sealed class LoadingScreensEntry
{
    [Index(true)]
    public uint ID;
    public string Name = string.Empty;
    public string FileName = string.Empty;
    public int HasWideScreen;
}
