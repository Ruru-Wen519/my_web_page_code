using webapi_order_system.Models;

var builder = WebApplication.CreateBuilder(args);

//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
// �]�w CORS�A�u���\�A���e�ݺ��}
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyWebPage", policy =>
    {
        policy.WithOrigins("https://web-front-code.onrender.com") // �����A���e�ݺ��}
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//^_^ 20250701 add by lisa for �ҥ� CORS ==E==
//^_^ 20250701 add by lisa for �t�m HTTPS �ݤf ==S==
// �t�m HTTPS �ݤf
//builder.WebHost.UseKestrel(options =>
//{
//    options.ListenLocalhost(5000);
//    options.ListenLocalhost(5001, listenOptions =>
//    {
//        listenOptions.UseHttps();
//    });
//});
//^_^ 20250701 add by lisa for �t�m HTTPS �ݤf ==E==

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

try
{
	var app = builder.Build();

	//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
	app.Use(async (context, next) =>
	{
		context.Response.Headers.Add("Access-Control-Allow-Origin", "https://web-front-code.onrender.com");
		await next();
	});
	// �ҥ� CORS
	app.UseCors("AllowMyWebPage");
	//^_^ 20250701 add by lisa for �ҥ� CORS ==E==

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

	//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
	// �s�W���Ѱt�m
	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	app.MapPost("/api/orders", async (context) =>
	{
		// �B�z POST �ШD���޿�
		var order = await context.Request.ReadFromJsonAsync<Order>();
		// ...
		await context.Response.WriteAsync("Order received");
	});
	//^_^ 20250701 add by lisa for �ҥ� CORS ==E==


	app.Run();
}
catch (Exception ex)
{
    // �O�����`��T
    Console.WriteLine($"An error occurred: {ex.Message}");
    Console.WriteLine(ex.StackTrace);

    // �i�H�b�o�̲K�[��L���`�B�z�޿�,�Ҧp:
    // - ��^���~�T�����Ȥ��
    // - �q���޲z��
    // - �����L���~�B�z�ʧ@
}


