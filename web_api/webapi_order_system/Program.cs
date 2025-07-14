using Microsoft.EntityFrameworkCore;
using webapi_order_system.Models;

var builder = WebApplication.CreateBuilder(args);


//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyWebPage", policy =>
    {
        policy.WithOrigins("https://web-front-code.onrender.com")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//^_^ 20250701 add by lisa for CORS ==E==
// Add services to the container.

builder.Services.AddControllers();

//^_^ 20250701 add by lisa for database  ==S==
builder.Services.AddDbContext<web_designContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase")));
//^_^ 20250701 add by lisa for database ==E==

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//^_^ 20250701 add by lisa for  CORS ==S==
// �ҥ� CORS
app.UseCors("AllowMyWebPage");
//^_^ 20250701 add by lisa for  CORS ==E==

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
