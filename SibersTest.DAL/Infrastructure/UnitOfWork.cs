using SibersTest.DAL.EF;
using SibersTest.DAL.Repositories;
using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectRepository projectRepository;
        private EmployeeRepository employeeRepository;
        private ProjectDbContext dbContext;

        public UnitOfWork(string connectionString)
        {
            dbContext = new ProjectDbContext(connectionString);
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(dbContext);
                return employeeRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(dbContext);
                return projectRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
