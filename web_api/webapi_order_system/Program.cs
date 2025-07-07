using webapi_order_system.Models;

var builder = WebApplication.CreateBuilder(args);

//^_^ 20250701 add by lisa for 啟用 CORS ==S==
// 設定 CORS，只允許你的前端網址
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyWebPage", policy =>
    {
        policy.WithOrigins("https://ruru-wen519.github.io") // 換成你的前端網址
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//^_^ 20250701 add by lisa for 啟用 CORS ==E==
//^_^ 20250701 add by lisa for 配置 HTTPS 端口 ==S==
// 配置 HTTPS 端口
//builder.WebHost.UseKestrel(options =>
//{
//    options.ListenLocalhost(5000);
//    options.ListenLocalhost(5001, listenOptions =>
//    {
//        listenOptions.UseHttps();
//    });
//});
//^_^ 20250701 add by lisa for 配置 HTTPS 端口 ==E==

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

try
{
	var app = builder.Build();


	//^_^ 20250701 add by lisa for 啟用 CORS ==S==
	app.Use(async (context, next) =>
	{
		context.Response.Headers.Add("Access-Control-Allow-Origin", "https://ruru-wen519.github.io");
		await next();
	});
	// 啟用 CORS
	app.UseCors("AllowMyWebPage");
	//^_^ 20250701 add by lisa for 啟用 CORS ==E==

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
        //app.UseHttpsRedirection(); //lisa
    }
    //lisa ==S==
    //app.UseRouting();
    //app.UseEndpoints(endpoints =>
    //{
    //    endpoints.MapControllers();
    //});
    //lisa ==E==
    app.UseHttpsRedirection();

	app.UseAuthorization();

	//app.MapControllers();//^_^ 20250701 mark by lisa 

	//^_^ 20250701 add by lisa for 啟用 CORS ==S==
	// 新增路由配置
	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	app.MapPost("/api/orders", async (context) =>
	{
		// 處理 POST 請求的邏輯
		var order = await context.Request.ReadFromJsonAsync<Order>();
		// ...
		await context.Response.WriteAsync("Order received");
	});
	//^_^ 20250701 add by lisa for 啟用 CORS ==E==


	app.Run();
}
catch (Exception ex)
{
    // 記錄異常資訊
    Console.WriteLine($"An error occurred: {ex.Message}");
    Console.WriteLine(ex.StackTrace);

    // 可以在這裡添加其他異常處理邏輯,例如:
    // - 返回錯誤訊息給客戶端
    // - 通知管理員
    // - 執行其他錯誤處理動作
}


