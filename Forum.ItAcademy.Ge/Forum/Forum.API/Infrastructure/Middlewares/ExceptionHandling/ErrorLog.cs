using Forum.API.Infrastructure.Localizations;
using Forum.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Forum.API.Infrastructure.Middlewares.ExceptionHandling
{
    public class ErrorLog : ProblemDetails
    {
        public const string UnhandledErrorCode = "UnhandledError";

        private readonly HttpContext _httpContext;
        private readonly Exception _exception;

        public LogLevel LogLevel { get; set; }
        public string Message { get; set; } = default!;
        public string Code { get; set; } = default!;

        public ErrorLog(HttpContext httpContext, Exception exception)
        {
            _httpContext = httpContext;
            _exception = exception;

            Extensions["TraceId"] = httpContext.TraceIdentifier;
            Instance = httpContext.Request.Path;

            HandleException((dynamic)exception);
        }

        private void HandleException(Exception exception)
        {
            Code = UnhandledErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.UnhandledErrorOccurred;
        }

        private void HandleException(UserNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.UserNotFound;
        }

        private void HandleException(InvalidPasswordException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Unauthorized;
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.InvalidPassword;
        }

        private void HandleException(UnauthorizedException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Unauthorized;
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.Unauthorized;
        }

        private void HandleException(CouldNotRegisterException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.UnhandledErrorOccurred;
        }

        private void HandleException(EmailAlreadyExistsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.EmailAlreadyExists;
        }

        private void HandleException(UsernameAlreadyExistsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Message = ErrorMessages.UsernameAlreadyExists;
        }
    }
}
