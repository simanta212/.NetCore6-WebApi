using HotelListing.IRepository;
using Microsoft.EntityFrameworkCore;
using NotOYO.Models;
using NotOYO.Repository;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddMvc();
builder.Services.AddMvcCore();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Host.UseSerilog();
builder.Services.AddDbContext<Mapper>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors( o =>
{
    o.AllowAnyOrigin();
    o.AllowAnyHeader();
    o.AllowAnyMethod();
});

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Run();


Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.WriteTo.Console()
.WriteTo.File(path: "d:\\.Net Projects\\.Net Core Api\\NotOYO\\Logs\\log-.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information)
.CreateLogger();
try
{
    Log.Information("Application Is Starting");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application Failed to start");
}
finally
{
    Log.CloseAndFlush();
}

