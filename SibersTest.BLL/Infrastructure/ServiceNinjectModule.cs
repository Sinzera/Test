using Ninject.Modules;
using SibersTest.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.BLL.Infrastructure
{
    public class ServiceNinjectModule : NinjectModule
    {
        private string connectionString;

        public ServiceNinjectModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
