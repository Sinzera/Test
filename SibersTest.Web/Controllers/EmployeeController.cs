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
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService emloyeeService)
        {
            this.employeeService = emloyeeService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = employeeService.GetEmployees();
            var employeesView = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(employeesView);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var employeeDetails = Mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(employeeDetails);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            Employee employee = Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
            var errors = employeeService.CanAddEmployee(employee);
            ModelState.AddModelErrors(errors);
            if (ModelState.IsValid)
            {
                employeeService.CreateEmployee(employee);
                return RedirectToAction("Details", new { id = employee.EmployeeId });
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var employeeToEdit = Mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(employeeToEdit);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel employeeViewModel)
        {
            Employee employeeToEdit = Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
            var errors = employeeService.CanAddEmployee(employeeToEdit).ToList();
            ModelState.AddModelErrors(errors);
            if (ModelState.IsValid)
            {
                employeeService.EditEmployee(employeeToEdit);
                return RedirectToAction("Index", new { id = employeeToEdit.EmployeeId });
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var employeeToDelete = Mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(employeeToDelete);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            employeeService.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
