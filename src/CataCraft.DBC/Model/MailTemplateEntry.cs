using CataCraft.DBC.Attributes;
using DBCD.IO.Attributes;

namespace CataCraft.DBC.Model;

[DBFile("MailTemplate.dbc")]
public sealed class MailTemplateEntry
{
    [Index(false)]
    public uint ID;
    public string Subject = string.Empty;
    public string Body = string.Empty;
}
