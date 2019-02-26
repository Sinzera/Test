﻿using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using SibersTest.BLL.Infrastructure;
using SibersTest.Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SibersTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => {
                cfg.AddProfile<AutoMapperConfiguration>();
            });

            // Dependency
            NinjectModule webNinjectModule = new WebNinjectModule();
            NinjectModule serviceNinjectModule = new ServiceNinjectModule("SibersTestConnection");
            var kernel = new StandardKernel(webNinjectModule, serviceNinjectModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}