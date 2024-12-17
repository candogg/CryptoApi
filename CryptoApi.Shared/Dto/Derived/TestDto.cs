using CryptoApi.Shared.Attributes;
using CryptoApi.Shared.Dto.Base;

namespace CryptoApi.Shared.Dto.Derived
{
    public sealed class TestDto : DtoBase
    {
        [Encrypt(true)]
        public string Name { get; set; } = null!;

        [Encrypt(true)]
        public string Surname { get; set; } = null!;

        [Encrypt(false)]
        public string? Description { get; set; }
    }
}
