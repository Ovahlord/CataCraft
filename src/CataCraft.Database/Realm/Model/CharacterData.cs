// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm.Model;

[PrimaryKey(nameof(CharacterId), nameof(Id))]
public class CharacterData
{
    public int CharacterId { get; set; }
    public int Id { get; set; }
    public DateTimeOffset Time { get; set; }
    public byte[] Data { get; set; } = [];

    // Navigation property
    public Character Character { get; set; } = null!;
}
