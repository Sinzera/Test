using SibersTest.BLL.Infrastructure;
using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects();
        Project GetProject(int id);
        IEnumerable<Project> SearchProject(string project);
        IEnumerable<Project> GetFilteredProjects(string sortBy, string filterBy, string filterDate1, string filterDate2);
        IEnumerable<ValidationResult> CanAddProject(Project newProject);
        void CreateProject(Project newProject);
        void EditProject(Project projectToEdit);
        void DeleteProject(int id);
        void SaveProject();
    }
}
