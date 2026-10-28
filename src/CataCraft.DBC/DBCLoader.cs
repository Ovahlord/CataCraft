// This file is part of the CataCraft project, which is published under the MIT license.

using System.Text;

namespace CataCraft.DBC;

public static class DBCLoader
{
    public static async Task LoadStorageAsync<T>(string storageFilePath, IDictionary<int, T> storage, CancellationToken token = default) where T : new()
    {
        if (string.IsNullOrWhiteSpace(storageFilePath))
            throw new ArgumentNullException(nameof(storageFilePath));

        if (!File.Exists(storageFilePath))
            throw new FileNotFoundException(storageFilePath);

        using FileStream fs = File.OpenRead(storageFilePath);
        byte[] identifierBuffer =  new byte[4];
        await fs.ReadExactlyAsync(identifierBuffer, token);
        string identifier = Encoding.UTF8.GetString(identifierBuffer);

        switch (identifier)
        {
            case "WDBC":
                await WDBCReader.ReadStorageAsync(fs, storage, token);
                break;
            case "WDB2":
                await WDB2Reader.ReadStorageAsync(fs, storage, token);
                break;
            default:
               throw new NotImplementedException($"Not implemented/unsupported storage type: {identifier}");
        }
    }
}
