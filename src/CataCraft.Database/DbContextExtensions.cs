// This file is part of the CataCraft project, which is published under the MIT license.

using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database;

public static class DbContextExtensions
{
    extension(DbContext context)
    {
        public async Task ImportJsonTableAsync<TEntity>(string tableName, string importDataPath, CancellationToken cancellationToken) where TEntity : class
        {
            try
            {
                // First we check if the table has any data in it already - if yes, we don't want to import any default data
                if (await context.Set<TEntity>().AnyAsync(cancellationToken))
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
}
