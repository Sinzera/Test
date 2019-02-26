using AutoMapper;
using SibersTest.BLL.Interfaces;
using SibersTest.Model.Models;
using SibersTest.Web.Extensions;
using SibersTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTest.Web.Controllers
{
    public class ProjectController : Controller
    {
        IProjectService projectService;
        IEmployeeService employeeService;

        public ProjectController(IProjectService projectService, IEmployeeService employeeService)
        {
            this.projectService = projectService;
            this.employeeService = employeeService;
        }

        // GET: Project
        public ActionResult Index(string sortBy = "Name", string filterByPriority = "All", string filterDate1 = null, string filterDate2 = null)
        {
            var projects = projectService.GetFilteredProjects(sortBy, filterByPriority, filterDate1, filterDate2).ToList();
            var projectsViewModel = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);
            var projectListViewModel = new ProjectListViewModel(filterByPriority, sortBy, filterDate1, filterDate2);
            projectListViewModel.ProjectsViewModel = projectsViewModel;
            return View(projectListViewModel);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            var projectDetails = Mapper.Map<Project, ProjectViewModel>(project);
            return View(projectDetails);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel projectViewModel)
        {
            Project project = Mapper.Map<ProjectViewModel, Project>(projectViewModel);
            var errors = projectService.CanAddProject(project);
            ModelState.AddModelErrors(errors);
            if (ModelState.IsValid)
            {
                projectService.CreateProject(project);
                return RedirectToAction("Details", new { id = project.ProjectId });
            }
            return View(projectViewModel);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            var projectToEdit = Mapper.Map<Project, ProjectViewModel>(project);
            var employees = employeeService.GetEmployees().ToList();
            var managersList = new SelectList(employees, "EmployeeId", "LastName", project.ManagerId);
            var employeesList = new MultiSelectList(employees, "EmployeeId", "LastName", project.Employees.Select(e => e.EmployeeId));
            ViewBag.ManagersList = managersList;
            ViewBag.EmployeesList = employeesList;
            return View(projectToEdit);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectViewModel projectViewModel)
        {
            Project projectToEdit = Mapper.Map<ProjectViewModel, Project>(projectViewModel);
            var errors = projectService.CanAddProject(projectToEdit).ToList();
            ModelState.AddModelErrors(errors);
            if (ModelState.IsValid)
            {
                var projectEmployees = new List<Employee>();
                foreach (var employeeId in projectViewModel.EmployeesId)
                {
                    var employee = employeeService.GetEmployee(employeeId);
                    projectEmployees.Add(employee);
                }
                projectToEdit.Employees = projectEmployees;
                projectService.EditProject(projectToEdit);
                return RedirectToAction("Index", new { id = projectToEdit.ProjectId });
            }
            var employees = employeeService.GetEmployees().ToList();
            var managersList = new SelectList(employees, "EmployeeId", "LastName", projectToEdit.ManagerId);
            var employeesList = new MultiSelectList(employees, "LastName", projectToEdit.Employees.Select(e => e.EmployeeId));
            ViewBag.ManagersList = managersList;
            ViewBag.EmployeesList = employeesList;
            return View(projectViewModel);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            var projectToDelete = Mapper.Map<Project, ProjectViewModel>(project);
            return View(projectToDelete);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            projectService.DeleteProject(id);
            return RedirectToAction("Index", "Project");
        }
    }
}
