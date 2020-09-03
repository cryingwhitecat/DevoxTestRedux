using DevoxTestRedux.Application.Interfaces;
using DevoxTestRedux.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Projects.Queries
{
    class GetAllProjectsQuery: IRequest<ProjectsModel>
    {
        class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ProjectsModel>
        {
            private readonly IApplicationDBContext applicationDBContext;
            public GetAllProjectsHandler(IApplicationDBContext context)
            {
                applicationDBContext = context;
            }
            public async Task<ProjectsModel> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
            {
                return new ProjectsModel() { Projects = applicationDBContext.Projects.ToList() };
            }
        }
    }
}
