using Microsoft.EntityFrameworkCore;
using webapi_order_system.Models;

var builder = WebApplication.CreateBuilder(args);


//^_^ 20250701 add by lisa for 啟用 CORS ==S==
// 設定 CORS，只允許你的前端網址
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyWebPage", policy =>
    {
        policy.WithOrigins("https://web-front-code.onrender.com") // 換成你的前端網址
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithMethods("GET", "POST", "PUT", "DELETE") // 允許的 HTTP 方法
              .WithHeaders("authorization", "content-type"); // 允許的請求標頭
    });
});

//^_^ 20250701 add by lisa for 啟用 CORS ==E==
// Add services to the container.

builder.Services.AddControllers();

//^_^ 20250701 add by lisa for 連接資料庫 ==S==
builder.Services.AddDbContext<web_designContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase")));
//^_^ 20250701 add by lisa for 連接資料庫 ==E==

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//^_^ 20250701 add by lisa for 啟用 CORS ==S==
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "https://web-front-code.onrender.com");
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
