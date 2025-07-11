using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using webapi_order_system.Dto;
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

        private readonly web_designContext _web_DesignContext;
        public dataController (web_designContext web_Design)
        {
            _web_DesignContext = web_Design;
        }

        [HttpPost]

        public ResponseDto login([FromBody] RequestDto request)
        {
            ResponseDto response = new ResponseDto();

            //DataTable dataTable = new DataTable();

            // 執行原生 SQL 查詢並將結果轉換為 DataTable
            //string query = "SELECT * FROM [login_data] WHERE login_name = '@login_name' AND login_password = '@login_password'";
            //var parameters = new[] { new SqlParameter("@login_name", request.account_input), new SqlParameter("@login_password", request.password_input) };
            string query = "SELECT * FROM [login_data] WHERE login_name = '" + request.account_input + "' AND login_password = '" + request.password_input + "'";

            var dto_Login_Datas = _web_DesignContext.Set<login_data>().FromSqlRaw(query).ToList();

            if (dto_Login_Datas.Count > 0)
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

    }
}
