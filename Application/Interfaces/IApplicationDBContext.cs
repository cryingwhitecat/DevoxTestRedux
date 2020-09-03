using DevoxTestRedux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Interfaces
{
    /// <summary>
    /// Represents a basic DbContext that can be modified in case of changed requeirements.
    /// </summary>
    public interface IApplicationDBContext
    {
        DbSet<Project> Projects { get; set; }
        Task SaveChangesAsync();
    }
}
