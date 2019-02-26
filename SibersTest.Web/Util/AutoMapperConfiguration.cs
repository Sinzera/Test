using AutoMapper;
using SibersTest.Model.Models;
using SibersTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTest.Web.Util
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Project, ProjectViewModel>();

            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<ProjectViewModel, Project>();
        }
    }
}