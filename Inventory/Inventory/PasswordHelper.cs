using System.Security.Cryptography;

namespace inventory;

public static class PasswordHelper
{
    private const int Iterations = 100_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
        return $"PBKDF2${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        try
        {
            string[] parts = storedHash.Split('$');
            if (parts.Length != 4 || parts[0] != "PBKDF2") return false;

            int iterations = int.Parse(parts[1]);
            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] originalHash = Convert.FromBase64String(parts[3]);

            byte[] newHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, originalHash.Length);
            return CryptographicOperations.FixedTimeEquals(newHash, originalHash);
        }
        catch
        {
            return false;
        }
    }
}
