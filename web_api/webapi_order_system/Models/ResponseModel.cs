// Models/RequestModel.cs
namespace webapi_order_system.Models
{
    public class ResponseModel
    {
        //帳密是否正確
        public string is_correct { get; set; } = "0";


        public string message { get; set; } = "";
    }
}