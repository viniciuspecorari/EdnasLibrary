using EdnasLibrary.Application.Responses;
using System.Net;
using System.Text.Json;

namespace EdnasLibrary.Api.Middleware
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ErrorHandlerMiddleware> _Logger  = logger;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            // Verificar o tipo da exceção 
            if (exception is ErrorResponse errorResponse)
            {
                httpContext.Response.StatusCode = errorResponse.StatusCode;
                var response = new
                {
                    statusCode = errorResponse.StatusCode,
                    errorMessage = errorResponse.ErrorMessage,
                    details = errorResponse.Details
                };

                var json = JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsync(json);
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new ErrorResponse 
                (
                    httpContext.Response.StatusCode,
                    "An unexpected error occurred. Please try again later.",
                    exception.StackTrace.ToString()
                );

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
