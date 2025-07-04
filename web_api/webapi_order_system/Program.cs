var builder = WebApplication.CreateBuilder(args);

//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
// �]�w CORS�A�u���\�A���e�ݺ��}
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyWebPage", policy =>
    {
        policy.WithOrigins("https://my-web-page-code.onrender.com") // �����A���e�ݺ��}
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//^_^ 20250701 add by lisa for �ҥ� CORS ==E==

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "https://my-web-page-code.onrender.com");
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
