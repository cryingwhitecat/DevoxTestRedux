using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Filters
{
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public APIExceptionFilterAttribute()
        { }
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }
        private void HandleException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(ValidationException))
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
            var details = new ValidationProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Validation Error",
            };
            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
