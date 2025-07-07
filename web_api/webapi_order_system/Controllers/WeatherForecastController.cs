using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi_order_system.Models;

namespace webapi_order_system.Controllers
{
    [EnableCors("AllowMyWebPage")]
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public IActionResult login([FromBody] RequestModel request)
        {
            var response = new
            {
                Message = $"Hello, {request.account_input}! Your age is {request.password_input}¡C",
                Success = true
            };
            return Ok(response);
        }
    }
}
