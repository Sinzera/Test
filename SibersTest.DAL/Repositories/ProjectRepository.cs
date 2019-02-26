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
    class ProjectRepository : RepositoryBase<Project>
    {
        public ProjectRepository(ProjectDbContext dbContext)
            : base(dbContext)
        { }
    }
}
