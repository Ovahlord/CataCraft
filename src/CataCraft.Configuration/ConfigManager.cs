// This file is part of the CataCraft project, which is published under the MIT license.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace CataCraft.Configuration;

public static class ConfigManager
{
    private static IConfiguration? s_configuration;

    public static void LoadConfiguration()
    {
        Console.WriteLine("Loading Config.json");

        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Config.json", optional: false);
        s_configuration = builder.Build();

        Console.WriteLine("Configuration successfully loaded");
    }

    public static bool TryGetConfigValue<T>(string key, [NotNullWhen(true)] out T? value)
    {
        if (s_configuration == null)
        {
            value = default;
            return false;
        }

        value = s_configuration.GetValue<T>(key);
        return value != null;
    }

    public static bool TryGetConfigValue<T>(string section, string key, [NotNullWhen(true)] out T? value)
    {
        if (s_configuration == null)
        {
            value = default;
            return false;
        }

        value = s_configuration.GetSection(section).GetValue<T>(key);
        return value != null;
    }

    public static bool TryGetConnectionString(string key, [NotNullWhen(true)] out string? connectionString)
    {
        if (s_configuration == null)
        {
            connectionString = null;
            return false;
        }

        connectionString = s_configuration.GetConnectionString(key);
        return connectionString != null;
    }
}
