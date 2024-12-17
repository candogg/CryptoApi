using System.Reflection;
using CryptoApi.Shared.Attributes;
using CryptoApi.Shared.Services.Derived;

namespace CryptoApi.Shared.Extensions
{
    public static class GenericExtensions
    {
        public static string Serialize(this object item)
        {
            return SerializationService.DerivedObject.SerializeObject(item);
        }

        public static T? Deserialize<T>(this object obj)
        {
            return SerializationService.DerivedObject.DeserializeObject<T>(obj);
        }

        public static T ProcessFieldCrypto<T>(this object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var encryptAttr = property.GetCustomAttribute<EncryptAttribute>();

                if (encryptAttr != null && encryptAttr.ShouldEncrypt)
                {
                    var value = property.GetValue(obj)?.ToString();

                    if (value != null && value.IsNotNullOrEmpty())
                    {
                        var encryptedValue = value.AsEncrypted();
                        property.SetValue(obj, encryptedValue);
                    }
                }
            }

            return (T)obj;
        }
    }
}
