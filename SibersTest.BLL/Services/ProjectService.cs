using SibersTest.BLL.Infrastructure;
using SibersTest.BLL.Interfaces;
using SibersTest.DAL.Infrastructure;
using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private IUnitOfWork unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Project> GetProjects()
        {
            return unitOfWork.Projects.GetAll().OrderBy(p => p.Name);
        }

        public Project GetProject(int id)
        {
            return unitOfWork.Projects.GetById(id);
        }

        public IEnumerable<ValidationResult> CanAddProject(Project newProject)
        {
            Project project;
            // If adding new employee
            if (newProject.ProjectId == 0)
                project = unitOfWork.Projects.Get(p => p.Name == newProject.Name);
            // If editing existing employee
            else
                project = unitOfWork.Projects.Get(p => p.Name == newProject.Name && p.ProjectId != newProject.ProjectId);

            if (project != null)
            {
                yield return new ValidationResult("Name", "Проект с таким именем уже существует.");
            }
            
            if (newProject.StartDate > newProject.EndDate)
            {
                yield return new ValidationResult("EndDate", "Дата конца проекта не может быть раньше даты начала.");
            }
            
            if (newProject.Priority < 1 && newProject.Priority > 3)
            {
                yield return new ValidationResult("Priority", "Приоритет должен быть 1, 2 или 3.");
            }
        }

        public void CreateProject(Project newProject)
        {
            unitOfWork.Projects.Create(newProject);
            SaveProject();
        }

        public void DeleteProject(int id)
        {
            var project = unitOfWork.Projects.GetById(id);
            unitOfWork.Projects.Delete(project);
            SaveProject();
        }

        public void EditProject(Project projectToEdit)
        {
            unitOfWork.Projects.Update(projectToEdit);
            SaveProject();
        }

        public IEnumerable<Project> GetFilteredProjects(string sortBy, string filterByPriority, string filterDate1, string filterDate2)
        {
            var projects = unitOfWork.Projects.GetAll();

            //priority filter
            int priority;
            bool prioritySelected = int.TryParse(filterByPriority, out priority);

            if (prioritySelected)
            {
                projects = projects.Where(p => p.Priority == priority);
            }

            //date filter
            DateTime? date1 = null, date2 = null;
            if (filterDate1 != null)
                date1 = DateTime.Parse(filterDate1);
            if (filterDate2 != null)
                date2 = DateTime.Parse(filterDate2);

            if (date1 != null)
            {
                projects = projects.Where(p => p.StartDate > date1);
            }

            if (date2 != null)
            {
                projects = projects.Where(p => p.StartDate < date2);
            }

            //sorting
            switch (sortBy)
            {
                case "Name":
                    {
                        projects = projects.OrderBy(p => p.Name);
                        break;
                    }
                case "StartDate":
                    {
                        projects = projects.OrderBy(p => p.StartDate);
                        break;
                    }
                case "EndDate":
                    {
                        projects = projects.OrderBy(p => p.EndDate);
                        break;
                    }
                case "Priority":
                    {
                        projects = projects.OrderBy(p => p.Priority);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return projects;
        }

        public void SaveProject()
        {
            unitOfWork.Save();
        }

        public IEnumerable<Project> SearchProject(string project)
        {
            var searchString = project.ToLower();
            return unitOfWork.Projects.GetMany(p => p.Name.ToLower().Contains(searchString)).OrderBy(p => p.Name);
        }
    }
}
