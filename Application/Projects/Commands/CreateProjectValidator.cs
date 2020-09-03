using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace DevoxTestRedux.Application.Projects.Commands
{
    /// <summary>
    /// Validation rules for CreateProjectCommand Dto.
    /// </summary>
    public class CreateProjectValidator: AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            //Project name can't be empty.
            RuleFor(cmd => cmd.ProjectName).NotEmpty();
        }
    }
}
