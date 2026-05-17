// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm.Model;

[PrimaryKey(nameof(RealmId), nameof(CharacterId))]
public class RealmCharacter
{
    public byte RealmId { get; set; }

    public int CharacterId { get; set; }

    public long GameAccountId { get; set; }

    public byte ListPositionIndex { get; set; }

    // Navigation properties
    public Realm Realm { get; set; } = null!;
    public Character Character { get; set; } = null!;
}
