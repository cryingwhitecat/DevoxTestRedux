using DevoxTestRedux.Application.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Common.Behaviors
{
    /// <summary>
    /// Pre-processor that validates every request
    /// </summary>
    /// <typeparam name="TRequest">Input request type.</typeparam>
    /// <typeparam name="TResponse">Output response type.</typeparam>
    class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        //Validators are injected in DI.cs
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        /// <summary>
        /// Validates an incoming request, and, if any errors occured, throws a <see cref="CustomValidationException"/>
        /// </summary>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new CustomValidationException(failures);
            }
            return await next();
        }
    }
}
