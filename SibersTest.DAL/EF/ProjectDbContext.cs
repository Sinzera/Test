using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibersTest.Model.Models;
using SibersTest.DAL.Configuration;

namespace SibersTest.DAL.EF
{
    class ProjectDbContext : DbContext
    {
        public ProjectDbContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
        }
    }
}
