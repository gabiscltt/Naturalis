using NaturalisBackend.Services;
using Microsoft.EntityFrameworkCore;
using NaturalisBackend.Database;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()  
                   .AllowAnyHeader(); 
        });
});

builder.Services.AddDbContext<NaturalisContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection")))); 

builder.Services.AddControllers();
builder.Services.AddScoped<TestService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();

