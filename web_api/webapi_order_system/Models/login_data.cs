using System;
using System.Collections.Generic;

namespace webapi_order_system.Models;

public partial class login_data
{
    public int ID { get; set; }

    public string login_name { get; set; } = null!;

    public string login_password { get; set; } = null!;
}
