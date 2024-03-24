
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.API.Infrastructure.Localizations;
using ToDo.Application.Exceptions;

namespace ToDo.API.Infrastructure.Middlewares
{
    public class ApiError : ProblemDetails
    {
        public const string UnhandledErrorCode = "UnhandledError";
        private HttpContext _httpContext;
        private Exception _exception;

        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }

        public string? TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                {
                    return (string?)traceId;
                }

                return null;
            }

            set => Extensions["TraceId"] = value;
        }

        public ApiError(HttpContext httpContext, Exception exception)
        {
            _httpContext = httpContext;
            _exception = exception;

            TraceId = httpContext.TraceIdentifier;

            Code = UnhandledErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = ErrorMessages.GlobalError;
            LogLevel = LogLevel.Error;
            Instance = httpContext.Request.Path;

            HandleException((dynamic)exception);
        }

        private void HandleException(InvalidEntityException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.InvalidEntity;
        }

        private void HandleException(InvalidPasswordException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.InvalidPassword;
        }

        private void HandleException(ToDoItemNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.ToDoItemNotFound;
        }

        private void HandleException(UserNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.UserNotFound;
        }

        private void HandleException(InvalidJwtTokenException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.InvalidJwtToken;
        }

        private void HandleException(InvalidClaimException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.InvalidClaim;
        }

        private void HandleException(InvalidParameterException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.InvalidParameter;
        }

        private void HandleException(ForbiddenOperationException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.ForbiddenOperation;
        }
        private void HandleException(SubtaskNotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.BadRequest;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            LogLevel = LogLevel.Information;
            Message = ErrorMessages.SubtaskNotFound;
        }

        private void HandleException(Exception exception)
        {
            Message = exception.Message;
        }
    }
}