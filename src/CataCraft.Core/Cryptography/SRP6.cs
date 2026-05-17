using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Salt = byte[];
using Verifier = byte[];
using EphemeralKey = byte[];
using SessionKey = byte[];

namespace CataCraft.Core.Cryptography;

public class SRP6
{
    public static int EphemeralKeyLength { get; set; } = 32;
    public static int SaltLength { get; set; } = 32;

    public static byte[] g { get; private set; }
    public static byte[] N { get; private set; }

    private static BigInteger _g { get; set; } // a [g]enerator for the ring of integers mod N, algorithm parameter
    private static BigInteger _N { get; set; } // the modulus, an algorithm parameter; all operations are mod this

    static SRP6()
    {
        g = [7];
        N = HexStringToByteArray("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7");
        _N = new(N, true);
        _g = new(g, true);
    }

    public SRP6(string username, byte[] salt, ReadOnlySpan<byte> verifier)
    {
        _I = SHA1.HashData(Encoding.ASCII.GetBytes(username.ToUpper()));

        Span<byte> bBuffer = stackalloc byte[32];
        RandomNumberGenerator.Fill(bBuffer);

        _b = new(bBuffer, true);
        _v = new(verifier, true);
        s = salt;
        B = _B(_b, _v);
    }

    private bool _used;

    // Per instanciation parameters - set on construction
    private readonly byte[] _I; // H(I) - the username, all uppercase
    private readonly BigInteger _b; // b - randomly chosen by the server, 19 bytes, never given out
    private readonly BigInteger _v; // v - the user's password verifier, derived from s + H(USERNAME || ":" || PASSWORD)
    public Salt s; // s - the user's password salt, random, used to calculate v on registration
    public EphemeralKey B; // B = 3v + g^b

    public static Tuple<Salt, Verifier> GenerateRegistrationData(string userName, string password)
    {
        // Initialize Salt
        byte[] salt = new byte[SaltLength];
        RandomNumberGenerator.Fill(salt);

        // Calculate Verifier
        byte[] verifier = CalculateVerifier(userName, password, salt);
        return new(salt, verifier);
    }

    public static Verifier CalculateVerifier(string username, string password, ReadOnlySpan<byte> salt)
    {
        // Convert username and password to uppercase and concatenate with ':'
        string userPass = username.ToUpper() + ":" + password.ToUpper();

        // Hash the concatenated string
        byte[] userPassHash = SHA1.HashData(Encoding.UTF8.GetBytes(userPass));

        // Concatenate salt and userPassHash
        Span<byte> saltUserPassHash = stackalloc byte[salt.Length + userPassHash.Length];
        salt.CopyTo(saltUserPassHash);
        userPassHash.CopyTo(saltUserPassHash.Slice(salt.Length, userPassHash.Length));

        // Hash the result again
        BigInteger x = new(SHA1.HashData(saltUserPassHash), true);

        // Calculate the verifier: v = g^x % N
        BigInteger v = BigInteger.ModPow(_g, x, _N);

        // Return the verifier as a byte array
        Span<byte> vSpan = stackalloc byte[EphemeralKeyLength];
        vSpan.Clear();
        v.ToByteArray(true).CopyTo(vSpan);

        return vSpan.ToArray();
    }

    public static byte[] _B(BigInteger b, BigInteger v)
    {
        // Calculate B = (g^b % N + v * 3) % N
        BigInteger bigB = (BigInteger.ModPow(_g, b, _N) + (v * 3)) % _N;

        Span<byte> bSpan = stackalloc byte[EphemeralKeyLength];
        bSpan.Clear();
        bigB.ToByteArray(true).CopyTo(bSpan);

        return bSpan.ToArray();
    }

    public static byte[] HexStringToByteArray(string hex)
    {
        int length = hex.Length;
        byte[] bytes = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }

        return bytes;
    }

    public static SessionKey SHA1Interleave(ReadOnlySpan<byte> S)
    {
        Span<byte> buf0 = stackalloc byte[EphemeralKeyLength / 2];
        Span<byte> buf1 = stackalloc byte[EphemeralKeyLength / 2];

        for (int i = 0; i < EphemeralKeyLength / 2; i++)
        {
            buf0[i] = S[2 * i];
            buf1[i] = S[2 * i + 1];
        }

        // Find the position of the first nonzero byte
        int p = 0;
        while (p < EphemeralKeyLength && S[p] == 0)
        {
            p++;
        }

        // skip one extra byte if p is odd
        if ((p & 1) != 0)
            ++p;

        p /= 2; // offset into buffers

        // Hash each half starting from the first nonzero byte
        byte[] hash0 = SHA1.HashData(buf0.Slice(p, EphemeralKeyLength / 2 - p));
        byte[] hash1 = SHA1.HashData(buf1.Slice(p, EphemeralKeyLength / 2 - p));

        // stick the two hashes back together
        Span<byte> K = stackalloc byte[hash0.Length + hash1.Length];
        for (int i = 0; i < SHA1.HashSizeInBytes; i++)
        {
            K[2 * i + 0] = hash0[i];
            K[2 * i + 1] = hash1[i];
        }

        return K.ToArray();
    }

    /// <summary>
    /// Generates the M2 value for the AuthLogonResponse packet
    /// </summary>
    /// <param name="A"></param>
    /// <param name="clientM"></param>
    /// <param name="K"></param>
    /// <returns></returns>
    public static byte[] GetSessionVerifier(ReadOnlySpan<byte> A, ReadOnlySpan<byte> clientM, ReadOnlySpan<byte> K)
    {
        Span<byte> combinedData = stackalloc byte[A.Length + clientM.Length + K.Length];
        combinedData.Clear();

        A.CopyTo(combinedData.Slice(0, A.Length));
        clientM.CopyTo(combinedData.Slice(A.Length, clientM.Length));
        K.CopyTo(combinedData.Slice(A.Length + clientM.Length, K.Length));

        return SHA1.HashData(combinedData);
    }

    public bool VerifyChallengeResponse(ReadOnlySpan<byte> A, ReadOnlySpan<byte> clientM, [NotNullWhen(true)] out SessionKey? K)
    {
        K = null;
        if (_used)
            throw new InvalidOperationException("A single SRP6 instance can only be used to verify once!");

        _used = true;

        BigInteger _A = new(A, true);
        if ((_A % _N).IsZero)
            return false;

        Span<byte> aB = stackalloc byte[A.Length + B.Length];
        A.CopyTo(aB.Slice(0, A.Length));
        B.CopyTo(aB.Slice(A.Length, B.Length));

        BigInteger u = new(SHA1.HashData(aB), true);

        Span<byte> S = stackalloc byte[EphemeralKeyLength];
        S.Clear();
        byte[] sBytes = BigInteger.ModPow(_A * BigInteger.ModPow(_v, u, _N), _b, _N).ToByteArray(true);
        sBytes.CopyTo(S);

        K = SHA1Interleave(S);

        // NgHash = H(N) xor H(g)
        byte[] NHash = SHA1.HashData(N);
        byte[] gHash = SHA1.HashData(g);

        Span<byte> NgHash = stackalloc byte[NHash.Length];
        for (int i = 0; i < NHash.Length; i++)
        {
            NgHash[i] = (byte)(NHash[i] ^ gHash[i]);
        }

        Span<byte> ourMSource = stackalloc byte[NgHash.Length + _I.Length + s.Length + A.Length + B.Length + K.Length];
        NgHash.CopyTo(ourMSource.Slice(0, NgHash.Length));
        _I.CopyTo(ourMSource.Slice(NgHash.Length, _I.Length));
        s.CopyTo(ourMSource.Slice(NgHash.Length + _I.Length, s.Length));
        A.CopyTo(ourMSource.Slice(NgHash.Length + _I.Length + s.Length, A.Length));
        B.CopyTo(ourMSource.Slice(NgHash.Length + _I.Length + s.Length + A.Length, B.Length));
        K.CopyTo(ourMSource.Slice(NgHash.Length + _I.Length + s.Length + A.Length + B.Length, K.Length));

        ReadOnlySpan<byte> ourM = SHA1.HashData(ourMSource);
        if (ourM.SequenceEqual(clientM))
            return true;

        return false;
    }
}
