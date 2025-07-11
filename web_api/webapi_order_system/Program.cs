using Microsoft.EntityFrameworkCore;
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
              .AllowAnyMethod()
              .WithMethods("GET", "POST", "PUT", "DELETE") // ���\�� HTTP ��k
              .WithHeaders("authorization", "content-type"); // ���\���ШD���Y
    });
});

//^_^ 20250701 add by lisa for �ҥ� CORS ==E==
// Add services to the container.

builder.Services.AddControllers();

//^_^ 20250701 add by lisa for �s����Ʈw ==S==
builder.Services.AddDbContext<web_designContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase")));
//^_^ 20250701 add by lisa for �s����Ʈw ==E==

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Access-Control-Allow-Origin", "https://web-front-code.onrender.com");
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
