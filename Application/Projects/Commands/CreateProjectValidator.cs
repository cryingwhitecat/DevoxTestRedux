using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace DevoxTestRedux.Application.Projects.Commands
{
    public class CreateProjectValidator: AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(cmd => cmd.ProjectName).NotEmpty();
        }
    }
}
