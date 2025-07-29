using Infrastructures.Interfaces.System;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Services.System
{
    public class StringeeUserRegistrationRequest
    {
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = "Consultant";
    }

    public class StringeeService(IConfiguration config) : IStringeeService
    {
        private readonly string _projectId = config["Stringee:ProjectId"]!;
        private readonly string _apiKeySid = config["Stringee:ApiKeySid"]!;
        private readonly string _apiKeySecret = config["Stringee:ApiKeySecret"]!;

        public async Task<string> RegisterUserAsync(StringeeUserRegistrationRequest request)
        {
            var client = new RestClient("https://api.stringee.com/v1/users");
            var restRequest = new RestRequest()
                .AddHeader("X-STRINGEE-AUTH", _apiKeySecret)
                .AddJsonBody(new
                {
                    userId = request.UserId,
                    name = request.FullName,
                    email = request.Email,
                    role = request.Role
                });

            var response = await client.PostAsync(restRequest);
            if (!response.IsSuccessful)
                throw new Exception("Failed to register user with Stringee.");

            return await GenerateAccessTokenAsync(Guid.Parse(request.UserId), request.Role);
        }

        public Task<string> GenerateAccessTokenAsync(Guid userId, string role)
        {
            // You can generate JWT token manually here if needed
            // Or return the accessToken from registration response
            return Task.FromResult("GENERATED_ACCESS_TOKEN"); // replace with real implementation
        }

        public async Task<string> SendSmsAsync(string phoneNumber, string message)
        {
            var client = new RestClient("https://api.stringee.com/v1/sms");
            var restRequest = new RestRequest()
                .AddHeader("X-STRINGEE-AUTH", _apiKeySecret)
                .AddJsonBody(new
                {
                    phoneNumber = phoneNumber,
                    message = message
                });

            var response = await client.PostAsync(restRequest);
            if (!response.IsSuccessful)
                throw new Exception("Failed to send SMS with Stringee.");

            return response.Content;
        }
    }
}
