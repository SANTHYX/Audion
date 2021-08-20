using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(ILogger logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = ex switch
                {
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _=> StatusCodes.Status500InternalServerError
                };
                var error = JsonSerializer.Serialize(
                    new ErrorResponse(response.StatusCode, ex.Message));
                await response.WriteAsync(error);
                _logger.LogError(ex.Message);
            }
        }
    }
}
