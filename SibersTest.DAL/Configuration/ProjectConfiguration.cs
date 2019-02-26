using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Configuration
{
    class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(150);
            Property(p => p.CustomerCompany).HasMaxLength(100);
            Property(p => p.PerformerCompany).HasMaxLength(100);
            Property(p => p.StartDate).IsRequired();
            Property(p => p.EndDate).IsRequired();
            Property(p => p.Priority).IsRequired();
            Property(p => p.Comment).HasMaxLength(500);
        }
    }
}
