using DevoxTestRedux.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Projects.Commands
{
    /// <summary>
    /// Dto used to create a new project.
    /// </summary>
    public class CreateProjectCommand: IRequest<int>
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }
}
