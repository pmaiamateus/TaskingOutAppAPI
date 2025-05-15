using Konscious.Security.Cryptography;
using System.Text;

namespace TaskingOutAppAPI.Middlewares;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        var salt = Settings.Salt;
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = saltBytes,
            DegreeOfParallelism = 1, // 1/2
            Iterations = 2,
            MemorySize = 15 * 1024 // 15MB
        };
        return Convert.ToBase64String(argon2.GetBytes(16));
    }

    public static bool VerifyHash(string password, string hash)
    {
        var newHash = HashPassword(password);
        return hash == newHash;
    }
}
