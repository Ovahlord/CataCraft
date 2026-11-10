// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core.Configuration;
using CataCraft.Database.Realm.Entities;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm;

public class RealmDbContext : DbContext
{
    public DbSet<Entities.Realm> Realms { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterStats> CharacterStats { get; set; }
    public DbSet<CharacterData> CharacterDataEntries { get; set; }
    public DbSet<CharacterInventory> CharacterItems { get; set; }
    public DbSet<ItemInstance> ItemInstances { get; set; }

    private static readonly string s_connectionString = GetConnectionString();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={s_connectionString}");
    }

    private static string GetConnectionString()
    {
        if (AppSettings.TryGetConnectionString("RealmDatabase", out string? connectionString))
            return connectionString;

        return string.Empty;
    }
}
