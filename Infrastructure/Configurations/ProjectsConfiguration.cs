using DevoxTestRedux.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoxTestRedux.Infrastructure.Configurations
{
    class ProjectsConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.ProjectName).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ProjectID).ValueGeneratedOnAdd();
        }
    }
}
