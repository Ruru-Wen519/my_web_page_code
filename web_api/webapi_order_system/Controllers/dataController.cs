using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi_order_system.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi_order_system.Controllers
{
    [EnableCors("AllowMyWebPage")]
    [Route("api/[controller]")]
    [ApiController]
    public class dataController : ControllerBase
    {
        //// GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<LoginController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<LoginController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<LoginController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LoginController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpPost]

        public ResponseModel login([FromBody] RequestModel request)
        {
            ResponseModel response = new ResponseModel();

            //DataTable dataTable = new DataTable();

            //// 讀取連接字串
            ////string connectionString = _configuration.GetConnectionString("DefaultConnection");
            ////if (string.IsNullOrEmpty(connectionString))
            ////{
            ////    // 處理 connectionString 為 null 或空字串的情況
            ////    throw new Exception("Connection string is not configured properly.");
            ////}
            //string connectionString = LoadConnectionString();
            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    // 處理 connectionString 為 null 或空字串的情況
            //    throw new Exception("Connection string is not configured properly.");
            //}

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    // 撈取 test01 資料表
            //    string query = "SELECT * FROM [test01] where username = '" + request.account_input + "' and userpassword = '" + request.password_input + "'";
            //    SqlCommand command = new SqlCommand(query, connection);
            //    SqlDataAdapter adapter = new SqlDataAdapter(command);
            //    adapter.Fill(dataTable);
            //}

            //if (dataTable.Rows.Count > 0)
            //{
            //    response.is_correct = "0";
            //}
            //else
            //{
            //    response.is_correct = "1";
            //}
            if ("2025".Equals(request.account_input))
            {
                response.is_correct = "0";
            }
            else
            {
                response.is_correct = "1";
            }
            response.message = "";
            return response;
        }

    }
}
