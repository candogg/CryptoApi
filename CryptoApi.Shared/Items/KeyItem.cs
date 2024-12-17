using CryptoApi.Shared.Extensions;

namespace CryptoApi.Shared.Items
{
    public sealed class KeyItem
    {
        public string Certificate { get; set; } = null!;
        public string KValue { get; set; } = null!;
        public string IValue { get; set; } = null!;

        public bool IsValid
        {
            get
            {
                return Certificate != null 
                    && KValue != null 
                    && IValue != null 
                    && Certificate.IsNotNullOrEmpty() 
                    && KValue.IsNotNullOrEmpty() 
                    && IValue.IsNotNullOrEmpty();
            }
        }
    }
}
