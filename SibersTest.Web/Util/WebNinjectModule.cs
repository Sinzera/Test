using Ninject.Modules;
using SibersTest.BLL.Interfaces;
using SibersTest.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTest.Web.Util
{
    public class WebNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IProjectService>().To<ProjectService>();
        }
    }
}