// This file is part of the CataCraft project, which is published under the MIT license.

using System.IO.Compression;

namespace CataCraft.Core.Utils;

public static class ZLib
{
    public static void InflateData(byte[] compressedData, Span<byte> destination)
    {
        using MemoryStream compressedMemoryStream = new(compressedData);
        using ZLibStream zLibStream = new(compressedMemoryStream, CompressionMode.Decompress);
        zLibStream.ReadExactly(destination);
    }

    public static byte[] DeflateData(ReadOnlySpan<byte> uncompressedData)
    {
        using MemoryStream compressedMemoryStream = new();
        using (ZLibStream zLibStream = new(compressedMemoryStream, CompressionMode.Compress))
            zLibStream.Write(uncompressedData);

        return compressedMemoryStream.ToArray();
    }
}
