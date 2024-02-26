using Newtonsoft.Json;
using PersonManagement.API.Infrastructure;
using Serilog;

namespace PizzaProject.API.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            var error = new ApiError(httpContext, ex);
            var log = JsonConvert.SerializeObject(error);
            var message = JsonConvert.SerializeObject(error.Message);

            Log.Error(log);

            httpContext.Response.Clear();
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = error.Status.Value;

            await httpContext.Response.WriteAsync(message);
        }
    }
}
