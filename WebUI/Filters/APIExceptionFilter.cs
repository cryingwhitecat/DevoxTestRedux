using DevoxTestRedux.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Filters
{
    /// <summary>
    /// Handles exceptions and returns appropriate responses. Used in Startup.cs
    /// </summary>
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public APIExceptionFilterAttribute()
        { }
        //Root exception handling method
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }
        private void HandleException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(CustomValidationException))
            {
                HandleValidationException(context);
                return;
            }
            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (CustomValidationException)context.Exception;
            var details = new ValidationProblemDetails(exception.Errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation Error",
            };
            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
