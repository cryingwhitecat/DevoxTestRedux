using DevoxTestRedux.Application.Interfaces;
using DevoxTestRedux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevoxTestRedux.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext,IApplicationDBContext
    {
        public DbSet<Project> Projects { get; set; }

        public async Task<int> SaveChangesAsync()
        {
           await base.SaveChangesAsync();
            return 0;
        }
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
