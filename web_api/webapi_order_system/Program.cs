var builder = WebApplication.CreateBuilder(args);

//^_^ 20250701 add by lisa for 啟用 CORS ==S==
// 設定 CORS，只允許你的前端網址
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyWebPage", policy =>
    {
        policy.WithOrigins("https://ruru-wen519.github.io/my_web_page_code/order_system/") // 換成你的前端網址
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//^_^ 20250701 add by lisa for 啟用 CORS ==E==

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//^_^ 20250701 add by lisa for 啟用 CORS ==S==
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "https://ruru-wen519.github.io/my_web_page_code/order_system/");
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
