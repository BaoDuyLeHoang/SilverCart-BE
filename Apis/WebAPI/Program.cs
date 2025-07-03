using System.Text;
using Infrastructures;
using WebAPI.Middlewares;
using WebAPI;
using Application.Commons;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// parse the configuration in appsettings
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddInfrastructuresService(configuration.DatabaseConnection);
builder.Services.AddSwaggerGeneration();
builder.Services.AddWebAPIService();
builder.Services.AddSerilog(lc => lc.WriteTo.Console().ReadFrom.Configuration(builder.Configuration));
builder.Services.AddSingleton(configuration);

builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.JWTSecretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();
/*
    register with singleton life time
    now we can use dependency injection for AppConfiguration
*/
var IsDevelopment = builder.Environment.IsDevelopment();
builder.Services.AddSingleton(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (IsDevelopment)
{
    configuration.IsDevelopment = true;
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.MapHealthChecks("/healthchecks");
app.UseHttpsRedirection();
// todo authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// this line tell intergrasion test
// https://stackoverflow.com/questions/69991983/deps-file-missing-for-dotnet-6-integration-tests
public partial class Program
{
}