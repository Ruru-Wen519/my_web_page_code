var builder = WebApplication.CreateBuilder(args);

//^_^ 20250701 add by lisa for 啟用 CORS ==S==
// 加這一段
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngularDev",
//        policy => policy.WithOrigins("http://localhost:4200")
//                        .AllowAnyHeader()
//                        .AllowAnyMethod());
//});

//// 加入 CORS 設定
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//});

// 設定 CORS，只允許你的前端網址
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://ruru-wen519.github.io") // 換成你的前端網址
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
// 加這一段
//app.UseCors("AllowAngularDev");
app.UseCors("AllowAll"); // 啟用 CORS
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
