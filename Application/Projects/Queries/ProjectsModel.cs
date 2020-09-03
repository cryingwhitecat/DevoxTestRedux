using DevoxTestRedux.Domain.Entities;
using System.Collections.Generic;

namespace DevoxTestRedux.Application.Projects.Queries
{
    public class ProjectsModel
    {
        public IList<Project> Projects { get; set; } = new List<Project>();
    }
}