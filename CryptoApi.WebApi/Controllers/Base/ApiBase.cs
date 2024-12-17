using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBase : ControllerBase
    {
        
    }
}
