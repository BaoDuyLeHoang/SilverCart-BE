using Infrastructures;
using WebAPI.Middlewares;
using WebAPI;
using Application.Commons;
using Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// parse the configuration in appsettings
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddInfrastructuresService(configuration.DatabaseConnection);
builder.Services.AddWebAPIService();
builder.Services.AddSingleton(configuration);

/*
    register with singleton life time
    now we can use dependency injection for AppConfiguration
*/
builder.Services.AddSingleton(configuration);

var app = builder.Build();

// Initialize SuperAdmin
using var scope = app.Services.CreateScope();
var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
await userService.CreateSuperAdminIfNotExists();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ResponseModificationMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<PerformanceMiddleware>();
app.MapHealthChecks("/healthchecks");
app.UseHttpsRedirection();
// todo authentication
app.UseAuthorization();

app.MapControllers();

app.Run();

// this line tell intergrasion test
// https://stackoverflow.com/questions/69991983/deps-file-missing-for-dotnet-6-integration-tests
public partial class Program
{
}