using Application.Commons;
using Infrastructures;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using Infrastructures.Services.System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SilverCart.Application.Commons;
using System.Text;
using VNPAY.NET;
using WebAPI;
using WebAPI.Extensions;
using WebAPI.Middlewares;

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
builder.Services.AddScoped<IStringeeService, StringeeService>();

//builder.Services.AddJwtAuthentication(builder.Configuration);

/*
    register with singleton lifetime
    now we can use dependency injection for AppConfiguration
*/
var IsDevelopment = builder.Environment.IsDevelopment();
builder.Services.AddSingleton(configuration);
var app = builder.Build();

app.Services.GetService<IVnpay>()?.Initialize(configuration.Vnpay.TmnCode,
    configuration.Vnpay.HashSecret, configuration.Vnpay.BaseUrl, configuration.Vnpay.ReturnUrl);
// Configure the HTTP request pipeline.
if (IsDevelopment)
{
    configuration.IsDevelopment = true;
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
// app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.MapHealthChecks("/healthchecks");
app.UseOutputCache();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.SeedDatabaseAsync();

app.Run();

// this line tell intergrasion test
// https://stackoverflow.com/questions/69991983/deps-file-missing-for-dotnet-6-integration-tests
public partial class Program
{
}