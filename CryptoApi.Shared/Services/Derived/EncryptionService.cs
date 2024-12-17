using System.Security.Cryptography;
using System.Text;
using CryptoApi.Shared.Constants;
using CryptoApi.Shared.Extensions;
using CryptoApi.Shared.Services.Base;

namespace CryptoApi.Shared.Services.Derived
{
    public sealed class EncryptionService : ServiceBase<EncryptionService>
    {
        public string EncryptString(string input)
        {
            if (input.IsNullOrEmpty() || SharedConstants.ApplicationKey == null || SharedConstants.ApplicationKey.IsNullOrEmpty() || SharedConstants.ApplicationIv == null || SharedConstants.ApplicationIv.IsNullOrEmpty()) return string.Empty;

            var outStr = string.Empty;

            try
            {
                using var aesAlg = Aes.Create();
                aesAlg.Key = Encoding.UTF8.GetBytes(SharedConstants.ApplicationKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(SharedConstants.ApplicationIv);

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(input);
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
            catch
            { }

            return outStr;
        }

        public string DecryptString(string input)
        {
            if (input.IsNullOrEmpty() || SharedConstants.ApplicationKey == null || SharedConstants.ApplicationKey.IsNullOrEmpty() || SharedConstants.ApplicationIv == null || SharedConstants.ApplicationIv.IsNullOrEmpty()) return string.Empty;

            var plaintext = string.Empty;

            try
            {
                using var aesAlg = Aes.Create();
                aesAlg.Key = Encoding.UTF8.GetBytes(SharedConstants.ApplicationKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(SharedConstants.ApplicationIv);

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using var msDecrypt = new MemoryStream(Convert.FromBase64String(input));
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                return srDecrypt.ReadToEnd();
            }
            catch
            { }

            return plaintext;
        }
    }
}
