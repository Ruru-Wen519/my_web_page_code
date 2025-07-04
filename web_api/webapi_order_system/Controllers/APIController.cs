using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_order_system.Models;

namespace webapi_order_system.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class APIController : ControllerBase
    //{
    //    [HttpGet]
    //    public string Get()
    //    {
    //        return "Hello, World!";
    //    }
    //}
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RequestModel request)
        {
            var response = new
            {
                Message = $"Hello, {request.account_input}! 你的年齡是 {request.password_input}。",
                Success = true
            };
            return Ok(response);
        }
    }
}
