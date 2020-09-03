using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevoxTestRedux.Application.Exceptions
{
    /// <summary>
    /// Custom validation exception that transforms a collection on
    /// <see cref="ValidationFailure"/> into a Dictionary fit for use in error filters in WebUI/> 
    /// 
    /// </summary>
    public class CustomValidationException: Exception
    {
        public Dictionary<string,string[]> Errors { get; private set; }
        public CustomValidationException(IEnumerable<ValidationFailure> errors)
        {
            //transform ValidationException's default Errors collection into a dictionary. 
            Errors = errors.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
