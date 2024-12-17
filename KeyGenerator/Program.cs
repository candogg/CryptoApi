using System.Security.Cryptography;
using System.Text;

var key = GeneratePassword(32);
var iv = GeneratePassword(16);

Console.Write($"Generated New Key: {key}\nGenerated New IV: {iv}");

using var rsa = RSA.Create();

var cryptedKey = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(key), RSAEncryptionPadding.OaepSHA256));
var cryptedIv = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(iv), RSAEncryptionPadding.OaepSHA256));

var rsaPrivateKey = rsa.ExportRSAPrivateKeyPem();

Console.Write($"\n\nCertificate (PEM)\n\n{rsaPrivateKey}");

Console.Write($"\n\nCrypted Key: {cryptedKey}\n\nCrypted IV: {cryptedIv}\n\n");

Console.ReadKey();

static string GeneratePassword(int length)
{
    var lower = "abcdefghijklmnopqrstuvwxyz";
    var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var special = "!@#$%^&*()-_=+[]{}|;:,.<>?/";
    var digits = "0123456789";
    var allChars = lower + upper + special + digits;

    using RandomNumberGenerator rng = RandomNumberGenerator.Create();
    var password = new StringBuilder(length);

    password.Append(GetRandomChar(rng, lower));
    password.Append(GetRandomChar(rng, upper));
    password.Append(GetRandomChar(rng, special));
    password.Append(GetRandomChar(rng, digits));

    for (var i = password.Length; i < length; i++)
    {
        password.Append(GetRandomChar(rng, allChars));
    }

    var passwordArray = password.ToString().ToCharArray();
    RandomizeArray(passwordArray);

    return new string(passwordArray);
}

static char GetRandomChar(RandomNumberGenerator rng, string charset)
{
    var randomBytes = new byte[1];
    rng.GetBytes(randomBytes);

    var randomIndex = randomBytes[0] % charset.Length;
    return charset[randomIndex];
}

static void RandomizeArray(char[] array)
{
    using var rng = RandomNumberGenerator.Create();

    var n = array.Length;

    while (n > 1)
    {
        n--;
        var k = GetRandomIndex(rng, n + 1);
        (array[n], array[k]) = (array[k], array[n]);
    }
}

static int GetRandomIndex(RandomNumberGenerator rng, int length)
{
    var randomBytes = new byte[1];
    rng.GetBytes(randomBytes);
    return randomBytes[0] % length;
}