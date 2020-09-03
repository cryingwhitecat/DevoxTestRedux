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
    public class GetAllProjectsQuery: IRequest<ProjectsModel>
    {}
}
