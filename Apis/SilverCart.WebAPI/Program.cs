using System.Text;
using Infrastructures;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebAPI.Middlewares;
using WebAPI;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SilverCart.Application.Commons;
using SilverCart.Infrastructure.Commons;
using VNPAY.NET;
using WebAPI.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Infrastructures.Commons.Exceptions;
using SilverCart.WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// parse the configuration in appsettings
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddApplicationService(configuration.DatabaseConnection);
builder.Services.AddSwaggerGeneration(builder);
builder.Services.AddMediatRServices();
builder.Services.AddWebAPIService();
builder.Services.AddSerilog(lc => lc.WriteTo.Console().ReadFrom.Configuration(builder.Configuration));
builder.Services.AddSingleton(configuration);
builder.Services.AddOutputCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

// Add SignalR services
builder.Services.AddSignalR();

// Configure CORS for SignalR
builder.Services.AddCors(options =>
{
    options.AddPolicy("ChatPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

//builder.Services.AddJwtAuthentication(builder.Configuration);

/*
    register with singleton lifetime
    now we can use dependency injection for AppConfiguration
*/
var IsDevelopment = builder.Environment.IsDevelopment();
builder.Services.AddSingleton(configuration);
Console.WriteLine(builder.Environment.EnvironmentName);

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
// app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.MapHealthChecks("/healthchecks");
app.UseOutputCache();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Map SignalR hub
app.MapHub<ChatHub>("/chatHub");

await app.SeedDatabaseAsync();

app.Run();

// this line tell intergrasion test
// https://stackoverflow.com/questions/69991983/deps-file-missing-for-dotnet-6-integration-tests
public partial class Program
{
}