using CryptoApi.Shared.Dto.Derived;
using CryptoApi.Shared.Extensions;
using CryptoApi.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.WebApi.Controllers.Derived
{
    public class TestController : ApiBase
    {
        [HttpPost("Test")]
        public async Task<ActionResult> Test(TestDto testData)
        {
            var finalData = testData.ProcessFieldCrypto<TestDto>();

            return await Task.FromResult(Ok(finalData));
        }
    }
}
