using Infrastructures;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using Infrastructures.Services.System;
using Serilog;
using VNPAY.NET;
using WebAPI;
using WebAPI.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using SilverCart.WebAPI.Hubs;
using WebAPI.Middlewares;
using SilverCart.Infrastructure.Commons;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// parse the configuration in appsettings
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddApplicationService(configuration);
builder.Services.AddSwaggerGeneration(builder);
builder.Services.AddMediatRServices();
builder.Services.AddWebAPIService();
builder.Services.AddApplicationDI(configuration);
builder.Services.AddSerilog(lc => lc.WriteTo.Console().ReadFrom.Configuration(builder.Configuration));
builder.Services.AddSingleton(configuration);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddOutputCache();
builder.Services.AddDistributedMemoryCache();
// Add SignalR services
builder.Services.AddSignalR();

// Configure HealthChecks
builder.Services.AddHealthChecks()
    .AddRedis(configuration.RedisConnection, name: "redis")
    .AddNpgSql(configuration.DatabaseConnection, name: "postgres");

// Configure CORS for SignalR
builder.Services.AddCors(options =>
{
    options.AddPolicy("ChatPolicy", builder =>
    {
        builder
            //.WithOrigins("http://localhost:5001")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
            //.AllowCredentials();
    });
});
builder.Services.AddScoped<IStringeeService, StringeeService>();


var IsDevelopment = builder.Environment.IsDevelopment();
builder.Services.AddSingleton(configuration);

var app = builder.Build();

app.Services.GetService<IVnpay>()?.Initialize(configuration.Vnpay.TmnCode,
    configuration.Vnpay.HashSecret, configuration.Vnpay.BaseUrl, configuration.Vnpay.ReturnUrl);
// Configure the HTTP request pipeline.
if (true)
{
    configuration.IsDevelopment = true;
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("ChatPolicy");

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseMiddleware<PerformanceMiddleware>();
app.MapHealthChecks("/healthchecks", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseOutputCache();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

await app.SeedDatabaseAsync(configuration);

app.Run();

// this line tell intergrasion test
// https://stackoverflow.com/questions/69991983/deps-file-missing-for-dotnet-6-integration-tests
public partial class Program
{
}