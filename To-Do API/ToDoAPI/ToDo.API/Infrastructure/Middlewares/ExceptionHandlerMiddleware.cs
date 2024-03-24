using Newtonsoft.Json;
using Serilog;

namespace ToDo.API.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
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
