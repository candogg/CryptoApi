using System.Security.Cryptography;
using System.Text;
using CryptoApi.Shared.Extensions;
using CryptoApi.Shared.Services.Derived;

namespace CryptoApi.Shared.Constants
{
    public static class SharedConstants
    {
        private static string? applicationKeyClear, applicationIvClear;
        public static string? ApplicationKey => applicationKeyClear;
        public static string? ApplicationIv => applicationIvClear;

        public static void LoadCertificateParametersToMemory(string? filePath)
        {
            if (filePath == null || filePath.IsNullOrEmpty()) return;

            var keyItem = FileService.DerivedObject.LoadKeys(filePath);

            if (!keyItem.IsValid) return;

            using var rsaPriv = RSA.Create();

            rsaPriv.ImportFromPem(keyItem.Certificate);

            try
            {
                applicationKeyClear = Encoding.UTF8.GetString(rsaPriv.Decrypt(Convert.FromBase64String(keyItem.KValue), RSAEncryptionPadding.OaepSHA256));
                applicationIvClear = Encoding.UTF8.GetString(rsaPriv.Decrypt(Convert.FromBase64String(keyItem.IValue), RSAEncryptionPadding.OaepSHA256));
            }
            catch
            { }
        }
    }
}
