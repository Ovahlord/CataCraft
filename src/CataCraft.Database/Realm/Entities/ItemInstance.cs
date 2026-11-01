// This file is part of the CataCraft project, which is published under the MIT license.

using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm.Entities;

[PrimaryKey(nameof(Id))]
public class ItemInstance
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int ItemDisplayId { get; set; }
}
