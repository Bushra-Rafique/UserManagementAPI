using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string ApiKeyQueryName = "api_key";
        private const string ApiKeyValue = "mysecret"; // example

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? token = null;

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var headerValue))
            {
                context.Request.Query.TryGetValue(ApiKeyQueryName, out var queryValue);
                token = queryValue;
            }
            else
            {
                token = headerValue;
            }

            if (token != ApiKeyValue)
            {
                _logger.LogWarning("Unauthorized request to {Path}", context.Request.Path);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{ \"error\": \"Unauthorized access.\" }");
                return;
            }

            await _next(context);
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
