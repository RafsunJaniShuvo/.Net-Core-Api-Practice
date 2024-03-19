using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [Route("get")]
        [HttpGet]
        public string GetName()
        {
            return "Rafsun jani shuvo";
        }
    }
}
