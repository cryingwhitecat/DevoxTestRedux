using DevoxTestRedux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevoxTestRedux.Application.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Project> Projects { get; set; }
        Task<int> SaveChangesAsync();
    }
}
