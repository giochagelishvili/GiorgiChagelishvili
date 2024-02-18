using CompanyManagement.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyManagement.API.Infrastructure
{
    public class ApiError : ProblemDetails
    {
        private const string UnhandlerErrorCode = "UnhandledError";
        private HttpContext HttpContext { get; set; }
        private Exception Ex { get; set; }
        private string Code { get; set; }
        private LogLevel LogLevel { get; set; }

        public string? TraceId
        {
            get => Extensions.TryGetValue("TraceId", out var traceId) ? (string?)traceId : null;
            set => Extensions["TraceId"] = value;
        }

        public ApiError(HttpContext httpContext, Exception ex)
        {
            HttpContext = httpContext;
            Ex = ex;
            TraceId = httpContext.TraceIdentifier;
            Code = UnhandlerErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = "მოხდა შეცდომა.";
            LogLevel = LogLevel.Error;
            Instance = httpContext.Request.Path;

            HandleException((dynamic)ex);
        }

        private void HandleException(CompanyNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        private void HandleException(UnauthorizedUserException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Unauthorized;
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
        }

        public override string ToString()
        {
            return $"Time: {DateTime.Now}" +
                    $"\nTrace ID: {HttpContext.TraceIdentifier}" +
                    $"\nCode: {Code}" +
                    $"\nStatus: {Status}" +
                    $"\nException message: {Ex.Message}" +
                    $"\nLog Level: {LogLevel}" +
                    $"\nInstance: {Instance}" +
                    $"\nStack trace: {Ex.StackTrace}" +
                    "\n-----------------------------\n";
        }
    }
}
