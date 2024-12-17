namespace CryptoApi.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EncryptAttribute(bool shouldEncrypt = true) : Attribute
    {
        public bool ShouldEncrypt { get; } = shouldEncrypt;
    }
}
