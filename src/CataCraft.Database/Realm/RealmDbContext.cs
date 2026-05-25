// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Configuration;
using CataCraft.Database.Realm.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Realm;

public class RealmDbContext : DbContext
{
    public DbSet<Model.Realm> Realms { get; set; }
    public DbSet<RealmCharacter> RealmCharacters { get; set; }
    public DbSet<Character> Characters { get; set; }

    private static readonly string s_connectionString = GetConnectionString();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={s_connectionString}");
    }

    private static string GetConnectionString()
    {
        if (ConfigManager.TryGetConnectionString("RealmDatabase", out string? connectionString))
            return connectionString;

        return string.Empty;
    }
}
