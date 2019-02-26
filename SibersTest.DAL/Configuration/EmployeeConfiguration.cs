using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibersTest.Model.Models;

namespace SibersTest.DAL.Configuration
{
    class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            Property(e => e.LastName).IsRequired().HasMaxLength(100);
            Property(e => e.MiddleName).HasMaxLength(100);
            Property(e => e.Email).HasMaxLength(100);
            HasMany(e => e.Projects).WithMany(p => p.Employees).
                Map(m => {
                    m.ToTable("EmployeeProject");
                    m.MapLeftKey("EmployeeId");
                    m.MapRightKey("ProjectId");
                });
        }
    }
}
