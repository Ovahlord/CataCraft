namespace CataCraft.DBC.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DBFileAttribute : Attribute
{
    public string FileName { get; }

    public DBFileAttribute(string fileName)
    {
        FileName = fileName;
    }
}
