using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class ResponseModificationMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseModificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Store original response body stream
            var originalBodyStream = context.Response.Body;

            try
            {
                // Create a new memory stream to capture the response
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                // Call the next middleware
                await _next(context);

                // Only process successful responses
                if (context.Response.StatusCode == 200)
                {
                    // Reset the stream position to read from beginning
                    responseBody.Seek(0, SeekOrigin.Begin);

                    // Read response stream into string
                    string responseContent;
                    using (var streamReader = new StreamReader(responseBody))
                    {
                        responseContent = await streamReader.ReadToEndAsync();
                    }

                    // If content exists and is not already wrapped in ResponseObject
                    if (!string.IsNullOrEmpty(responseContent) && !responseContent.Contains("\"statusCode\""))
                    {
                        // Deserialize the original response
                        var originalResponse = JsonConvert.DeserializeObject(responseContent);

                        // Create a new response object
                        var wrappedResponse =
                            new ResponseObject<object>(context.Response.StatusCode, "Success", originalResponse);

                        // Serialize the wrapped response
                        var wrappedResponseJson = JsonConvert.SerializeObject(wrappedResponse);

                        // Replace the response with wrapped version
                        context.Response.ContentType = "application/json";
                        var wrappedResponseBytes = Encoding.UTF8.GetBytes(wrappedResponseJson);

                        // Clear the response body for new content
                        responseBody.SetLength(0);
                        await responseBody.WriteAsync(wrappedResponseBytes, 0, wrappedResponseBytes.Length);
                    }

                    // Reset the stream position again to read from beginning
                    responseBody.Seek(0, SeekOrigin.Begin);
                }

                // Copy the modified stream back to the original response body
                await responseBody.CopyToAsync(originalBodyStream);
            }
            finally
            {
                // Restore the original stream
                context.Response.Body = originalBodyStream;
            }
        }
    }
}