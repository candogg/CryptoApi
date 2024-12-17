using CryptoApi.Shared.Extensions;
using CryptoApi.Shared.Items;
using CryptoApi.Shared.Services.Base;

namespace CryptoApi.Shared.Services.Derived
{
    public sealed class FileService : ServiceBase<FileService>
    {
        public KeyItem LoadKeys(string filePath)
        {
            try
            {
                if (File.Exists(filePath)) 
                {
                    var fileContent = File.ReadAllText(filePath).Trim();

                    var loadedKeyItem = fileContent.Deserialize<KeyItem>();

                    return loadedKeyItem ?? new KeyItem();
                }                
            }
            catch
            { }

            return new KeyItem();
        }
    }
}
