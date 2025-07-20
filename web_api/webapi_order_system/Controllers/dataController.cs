using Azure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Data;
using System.Security.Cryptography;
using System.Text;
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

        [HttpPost("login")]
        //[HttpPost]

        public ResponseDto login([FromBody] RequestDto request)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (string.IsNullOrEmpty(request.account_input) || string.IsNullOrEmpty(request.password_input))
                {
                    response.is_correct = "1";
                    response.message = "請輸入帳號或密碼!";
                }
                if ("0".Equals(request.entrance))
                {
                    //登入按鈕
                    login_comfirm(request, ref response);
                }
            }
            catch (Exception ex) {
                response.message = ex.Message;
            }

          
     
            return response;
        }

        [HttpPost("register")]
        public ResponseDto register([FromBody] RequestDto request)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (string.IsNullOrEmpty(request.account_input) || string.IsNullOrEmpty(request.password_input))
                {
                    response.is_correct = "1";
                    response.message = "請輸入帳號或密碼!";
                }
                if ("1".Equals(request.entrance))
                {
                    //註冊寫入
                    login_insert(request, ref response);

                }
            }
            catch (Exception ex) {
                response.is_correct = "1";
                response.message = ex.Message;
            }

            return response;
        }
        #region "測試"
        //public ResponseDto login([FromBody] RequestDto request)
        //{
        //    ResponseDto response = new ResponseDto();

        //    DataTable dataTable = new DataTable();
        //    //if ("2025".Equals(request.account_input))
        //    //{
        //    //    response.is_correct = "0";
        //    //}
        //    //else
        //    //{
        //    //    response.is_correct = "1";
        //    //}

        //    try
        //    {
        //        var cb = new SqlConnectionStringBuilder();
        //        cb.DataSource = "tcp:web-design-server.database.windows.net";
        //        cb.UserID = "Web";
        //        cb.Password = "bew_0519";
        //        cb.InitialCatalog = "web_design";

        //        using (var connection = new SqlConnection(cb.ConnectionString))
        //        {
        //            connection.Open();
        //            string query = "SELECT * FROM [login_data] WHERE login_name = '" + request.account_input + "' AND login_password = '" + request.password_input + "'";
        //            SqlCommand command = new SqlCommand(query, connection);
        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            adapter.Fill(dataTable);

        //        }
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            response.is_correct = "0";
        //        }
        //        else
        //        {
        //            response.is_correct = "1";
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //    response.message = "";
        //    return response;
        //}
        #endregion

        public void login_comfirm([FromServices] RequestDto request, ref ResponseDto response)
        {
            List<login_data> obj_login_datas = new List<login_data>();
            string hashedPassword = HashPassword(request.password_input);
            obj_login_datas = login_select(request, hashedPassword);

            if (obj_login_datas.Count > 0)
            {
                response.is_correct = "0";
            }
            else
            {
                response.is_correct = "1";
            }

        }

        public void login_insert([FromServices] RequestDto request, ref ResponseDto response)
        {
            List<login_data> obj_login_datas = new List<login_data>();
            string hashedPassword = HashPassword(request.password_input);
            obj_login_datas = login_select(request, hashedPassword);

            if (obj_login_datas.Count > 0)
            {
                //帳號已存在
                response.message = "帳號已存在!";
            }
            else
            {
                login_data obj_login_data = new login_data();
                obj_login_data.account_no = "lisa051920";
                obj_login_data.name = request.account_input;
                obj_login_data.password = hashedPassword;
                _web_DesignContext.Add(obj_login_data);
                _web_DesignContext.SaveChanges();
            }
           
        }

        public List<login_data> login_select([FromServices] RequestDto request, string hashedPassword)
        {
            List<login_data> obj_login_data = new List<login_data>();
            string query = "SELECT * FROM [login_data] WHERE [name] = '" + request.account_input + "'";
            if ("0".Equals(request.entrance))
            {
                //登入檢查帳號 + 密碼
                query += " AND password = '" + hashedPassword + "'";
            }
            else
            {
                //註冊檢查帳號是否已存在
            }

            obj_login_data = _web_DesignContext.Set<login_data>().FromSqlRaw(query).ToList();

            return obj_login_data;
        }

        #region"前端輸入的密碼加密"
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        #endregion
    }
}
