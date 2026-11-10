// This file is part of the CataCraft project, which is published under the MIT license.

using System.Text.Json;
using CataCraft.Core.Configuration;
using CataCraft.Database.Game.Entities;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Game;

public sealed class GameDbContext : DbContext
{
    public DbSet<CharacterStartPosition> CharacterStartPositions { get; set; }
    public DbSet<RequiredXpForLevel> RequiredXpForLevels { get; set; }

    private static readonly string s_connectionString = GetConnectionString();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={s_connectionString}")
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                await ImportJsonTableAsync<RequiredXpForLevel>(context, nameof(RequiredXpForLevels), cancellationToken);
            });
    }

    private static string GetConnectionString()
    {
        if (AppSettings.TryGetConnectionString("GameDatabase", out string? connectionString))
            return connectionString;

        return string.Empty;
    }

    private static async Task ImportJsonTableAsync<TEntity>(DbContext context, string tableName, CancellationToken cancellationToken) where TEntity : class
    {
        try
        {
            // First we check if the table has any data in it already - if yes, we don't want to import any default data
            if (await context.Set<TEntity>().AnyAsync(cancellationToken))
                return;

            if (!AppSettings.TryGetConfigValue("GameDataImportPath", out string? importDataPath))
                return;

            string importFilePath = Path.Combine(importDataPath, $"{tableName}.json");
            if (!File.Exists(importFilePath))
                return;

            Console.WriteLine($"Importing Json file: {Path.GetFileName(importFilePath)}");

            await using FileStream fs = File.OpenRead(importFilePath);
            List<TEntity>? result = await JsonSerializer.DeserializeAsync<List<TEntity>>(fs, cancellationToken: cancellationToken);
            if (result != null)
            {
                await  context.Set<TEntity>().AddRangeAsync(result, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
