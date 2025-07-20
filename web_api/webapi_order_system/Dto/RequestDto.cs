// Models/RequestModel.cs
namespace webapi_order_system.Dto
{
    public class RequestDto
    {
       /// <summary>
       /// 入口點，分辨要執行的方法
       /// </summary>
       public string entrance { get; set; } = "";
        public string account_input { get; set; } = "";
        public string password_input { get; set; } = "";
    }
}