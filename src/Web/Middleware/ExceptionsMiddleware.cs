using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
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
                    _=> StatusCodes.Status500InternalServerError
                };
                var error = JsonSerializer.Serialize(
                    new ErrorResponse(response.StatusCode, ex.Message));
                await response.WriteAsync(error);
            }
        }
    }
}
