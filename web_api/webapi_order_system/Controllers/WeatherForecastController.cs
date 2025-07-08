using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using webapi_order_system.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi_order_system.Controllers
{
    [EnableCors("AllowMyWebPage")]
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpPost]
        //public IActionResult login([FromBody] RequestModel request)
        //{
        //    var response = new
        //    {
        //        Message = $"Hello, {request.account_input}! Your age is {request.password_input}。",
        //        Success = true
        //    };
        //    return Ok(response);
        //}

        public ResponseModel login([FromBody] RequestModel request)
        {
            ResponseModel response = new ResponseModel();

            DataTable dataTable = new DataTable();

            // 讀取連接字串
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 撈取 test01 資料表
                string query = "SELECT * FROM [test01] where username = '" + request.account_input + "' and userpassword = '" + request.password_input + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            if (dataTable.Rows.Count > 0)
            {
                response.is_correct = "0";
            }
            else
            {
                response.is_correct = "1";
            }
            //if ("2025".Equals(request.account_input))
            //{
            //    response.is_correct = "0";
            //}
            //else
            //{
            //    response.is_correct = "1";
            //}
                response.message = "";
            return response;
        }

        private readonly IConfiguration _configuration;

        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
