using CryptoApi.Shared.Services.Derived;

namespace CryptoApi.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNullOrEmpty(this string? str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string AsEncrypted(this string str)
        {
            if (str.IsNullOrEmpty()) return str;

            return EncryptionService.DerivedObject.EncryptString(str);
        }

        public static string AsDecrypted(this string str)
        {
            if (str.IsNullOrEmpty()) return str;

            return EncryptionService.DerivedObject.DecryptString(str);
        }
    }
}
