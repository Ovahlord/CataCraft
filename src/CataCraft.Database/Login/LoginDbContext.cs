// This file is part of the CataCraft project, which is published under the MIT license.

using CataCraft.Database.Login.Model;
using Microsoft.EntityFrameworkCore;

namespace CataCraft.Database.Login;

public sealed class LoginDbContext : DbContext
{
    public DbSet<GameAccount> GameAccounts { get; set; }
    public DbSet<GameAccountBan> GameAccountBans { get; set; }
    public DbSet<GameAccountSessionData> GameAccountSessionDataEntries { get; set; }
    public DbSet<GameAccountSuspension> GameAccountSuspensions { get; set; }
    public DbSet<GameAccountData> GameAccountDataEntries { get; set; }
    public DbSet<GameAccountTutorial> GameAccountTutorials { get; set; }

    private static string ConnectionString => "login.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={ConnectionString}");
    }
}
