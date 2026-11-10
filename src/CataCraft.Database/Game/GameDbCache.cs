// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Database.Game.Entities;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Game;

public static class GameDbCache
{
    public static Dictionary<byte, RequiredXpForLevel> RequiredXpForLevels { get; private set; } = [];
    public static List<CharacterStartPosition> CharacterStartPositions { get; private set; } = [];

    public static async Task LoadDataAsync()
    {
        List<Task> loadingTasks =
        [
            Task.Run(async () =>
            {
                await using GameDbContext gameDb = new();
                return RequiredXpForLevels = await gameDb.RequiredXpForLevels
                    .AsNoTracking()
                    .ToDictionaryAsync(r => r.Level);
            }),

            Task.Run(async () =>
            {
                await using GameDbContext gameDb = new();
                return CharacterStartPositions = await gameDb.CharacterStartPositions
                    .AsNoTracking()
                    .ToListAsync();
            })
        ];

        await Task.WhenAll(loadingTasks);
    }
}
