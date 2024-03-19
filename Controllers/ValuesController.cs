using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDotNetCore.Controllers
{
    [Route("api/[controller]/[action]")] // If I want to get all action using single route [best practice and short ]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //[Route("get")]
        //[Route("[action]")] // if I want to access action name
        [HttpGet]
        public string GetName()
        {
            return "Rafsun jani shuvo";
        }

    }
}
