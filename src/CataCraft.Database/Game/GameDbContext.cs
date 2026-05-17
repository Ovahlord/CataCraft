// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Core;
using CataCraft.Core.Configuration;
using CataCraft.Database.Game.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Game;

public sealed class GameDbContext : DbContext
{
    public DbSet<CharacterCreationLocation> CharacterCreationLocations { get; set; }

    private static readonly string s_connectionString = GetConnectionString();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={s_connectionString}");
    }

    private static string GetConnectionString()
    {
        if (AppSettings.TryGetConnectionString("GameDatabase", out string? connectionString))
            return connectionString;

        return string.Empty;
    }
}
