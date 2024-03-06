using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using EtteplanMORE.ServiceManual.ApplicationCore.Services;
using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

const string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Database=ServiceManualDb;Integrated Security=True";

builder.Services.AddDbContext<ServiceManualDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Show enum values as strings in JSON.
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // Do not include null values in JSON.
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
}); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services.
builder.Services.AddScoped<IFactoryDeviceService, FactoryDeviceService>();
builder.Services.AddScoped<IMaintenanceTaskService, MaintenanceTaskService>();

WebApplication app = builder.Build();

// Ensure that the database exists and seed it with some data.
using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;

    // Reset the database for each run.
    ServiceManualDbContext dbContext = services.GetRequiredService<ServiceManualDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

    // Seed the database with some data.
    string factoryDeviceSeedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "factoryDeviceSeedData.csv");
    string maintenanceTaskSeedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maintenanceTaskSeedData.csv");
    SeedData.Initialize(services, factoryDeviceSeedFilePath, maintenanceTaskSeedFilePath);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();