using System;
using System.Collections.Generic;

namespace webapi_order_system.Models;

public partial class Dto_login_data
{
    public string name { get; set; } = null!;

    public string password { get; set; } = null!;
}
