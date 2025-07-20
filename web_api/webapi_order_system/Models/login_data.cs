using System;
using System.Collections.Generic;

namespace webapi_order_system.Models;

public partial class login_data
{
    public string account_no { get; set; } = null!;

    public string name { get; set; } = null!;

    public string password { get; set; } = null!;
}
