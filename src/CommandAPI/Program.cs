using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

var password = builder.Configuration["Password"];
var username = builder.Configuration["Username"];
var host = builder.Configuration["Host"];
var port = builder.Configuration["Port"];
var database = builder.Configuration["Database"];

string connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new 
   CamelCasePropertyNamesContractResolver();
}

);
builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
