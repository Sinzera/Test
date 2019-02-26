using SibersTest.DAL.EF;
using SibersTest.DAL.Infrastructure;
using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Repositories
{
    class EmployeeRepository : RepositoryBase<Employee>
    {
        public EmployeeRepository(ProjectDbContext dbContext)
            :base(dbContext)
        { }
    }
}
