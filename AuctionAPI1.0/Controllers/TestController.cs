using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI1._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Swagger is working!");
        }
    }
}
