using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace API.Middelware
{
    public class GlobalExceptionHandlingMiddelware : IMiddleware
    {
        public readonly ILogger<GlobalExceptionHandlingMiddelware> _logger;

        public GlobalExceptionHandlingMiddelware(ILogger<GlobalExceptionHandlingMiddelware> logger) => _logger = logger;


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server",
                    Title = "¡Ups, no pude controlar este error!",
                    Detail = ex.Message
                };

                string json = JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);

            }
        }
    }
}