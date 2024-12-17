using CryptoApi.Shared.Extensions;
using CryptoApi.Shared.Services.Base;
using Newtonsoft.Json;

namespace CryptoApi.Shared.Services.Derived
{
    public sealed class SerializationService : ServiceBase<SerializationService>
    {
        public T? DeserializeObject<T>(object obj)
        {
            if (obj == null) return Activator.CreateInstance<T>();

            try
            {
                var objStr = Convert.ToString(obj);

                if (objStr == null || objStr.IsNullOrEmpty())
                {
                    return Activator.CreateInstance<T>();
                }

                return JsonConvert.DeserializeObject<T>(objStr, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch
            { }

            return Activator.CreateInstance<T>();
        }

        public string SerializeObject(object obj, bool isCamelCase = false)
        {
            try
            {
                if (isCamelCase)
                {
                    return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    });
                }
                else
                {
                    return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                }
            }
            catch
            { }

            return string.Empty;
        }
    }
}
