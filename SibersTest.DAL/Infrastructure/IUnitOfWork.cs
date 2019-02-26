using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibersTest.Model.Models;

namespace SibersTest.DAL.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Project> Projects { get; }
        void Save();
    }
}
