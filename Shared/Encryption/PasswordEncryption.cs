using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Shared.Encryption;
public class PasswordEncryption
{
    /// <summary>
    /// Used for fully new passwords
    /// </summary>
    /// <param name="toEncode"></param>
    /// <returns></returns>
    public static string HashAndSalt(string toEncode)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(32);
        return Calculation(toEncode, salt);
    } //based upon old code https://github.com/BenjaminElifLarsen/basic/blob/main/BasicAuth.cs

    /// <summary>
    /// Used for comparing password where the salt is already known
    /// </summary>
    /// <param name="toEncode"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string HashAndSalt(string toEncode, byte[] salt)
    {
        return Calculation(toEncode, salt);
    }

    private static string Calculation(string toEncode, byte[] salt)
    {
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(toEncode, salt, KeyDerivationPrf.HMACSHA512, 100000, 32));
        return Convert.ToBase64String(salt) + hashed;
    }
}
