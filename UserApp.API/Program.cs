using Microsoft.EntityFrameworkCore;
using UserApp.Business;
using UserApp.Data.Context;
using UserApp.Data.Interfaces;
using UserApp.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

// Servicios DI
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GTrackAPI");
    c.RoutePrefix = string.Empty; //Configures swagger to load at application root
});

app.MapControllers();

app.Run();