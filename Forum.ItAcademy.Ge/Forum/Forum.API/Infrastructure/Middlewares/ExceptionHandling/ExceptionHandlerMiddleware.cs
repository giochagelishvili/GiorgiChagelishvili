using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace Forum.API.Infrastructure.Middlewares.ExceptionHandling
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            ApiError apiError = new(httpContext, ex);

            var log = JsonConvert.SerializeObject(apiError);
            var message = JsonConvert.SerializeObject(apiError.Message);

            Log.Error(message, log);

            httpContext.Response.Clear();
            httpContext.Response.ContentType = "application/json";

            if (apiError.Status.HasValue)
                httpContext.Response.StatusCode = apiError.Status.Value;
            else
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsync(log);
        }
    }
}
