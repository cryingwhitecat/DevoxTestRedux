using DevoxTestRedux.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Projects.Commands
{
    public class CreateProjectCommand: IRequest<int>
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
        {
            private readonly IApplicationDBContext applicationDBContext;
            public CreateProjectHandler(IApplicationDBContext context)
            {
                applicationDBContext = context;
            }
            public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {
                var p = new Domain.Entities.Project
                { 
                    ProjectName = request.ProjectName, 
                    ProjectID = request.ProjectID 
                };
                applicationDBContext.Projects.Add(p);
                await applicationDBContext.SaveChangesAsync();
                return p.ProjectID;
            }
        }

    }
}
