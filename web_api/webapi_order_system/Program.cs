var builder = WebApplication.CreateBuilder(args);

//^_^ 20250701 add by lisa for �ҥ� CORS ==S==
// �[�o�@�q
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngularDev",
//        policy => policy.WithOrigins("http://localhost:4200")
//                        .AllowAnyHeader()
//                        .AllowAnyMethod());
//});

//// �[�J CORS �]�w
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//});

// �]�w CORS�A�u���\�A���e�ݺ��}
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://ruru-wen519.github.io") // �����A���e�ݺ��}
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
// �[�o�@�q
//app.UseCors("AllowAngularDev");
app.UseCors("AllowAll"); // �ҥ� CORS
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
