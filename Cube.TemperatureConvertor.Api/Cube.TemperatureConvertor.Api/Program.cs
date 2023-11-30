using Cube.Data;
using Cube.TemperatureConvertor.Api.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
var filePath = Path.Combine(folder, "TemperatureConversionDB.db");

builder.Services.AddDbContext<TemperatureConversionDbContext>(options =>
{
    options.UseSqlite($"Data Source={filePath}");
});

// Add services to the container.
builder.Services.AddMediatR(builder => builder.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( option => { 
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "CUBE Temperature Convertor", Version = "v1" });
});
builder.Services.InjectServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }