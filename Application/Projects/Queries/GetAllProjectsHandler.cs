using DevoxTestRedux.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Projects.Queries
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ProjectsModel>
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
