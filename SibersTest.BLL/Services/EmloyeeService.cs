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
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return unitOfWork.Employees.GetAll().OrderBy(e => e.LastName);
        }

        public Employee GetEmployee(int id)
        {
            return unitOfWork.Employees.GetById(id);
        }

        public IEnumerable<ValidationResult> CanAddEmployee(Employee newEmployee)
        {
            Employee employeeNameCheck, employeeEmailCheck;
            // If adding new employee
            if (newEmployee.EmployeeId == 0)
            {
                employeeNameCheck = unitOfWork.Employees.Get(e => e.LastName == newEmployee.LastName && e.FirstName == newEmployee.FirstName && e.MiddleName == newEmployee.MiddleName);
                employeeEmailCheck = unitOfWork.Employees.Get(e => e.Email == newEmployee.Email);
            }
            // If editing existing employee
            else
            {
                employeeNameCheck = unitOfWork.Employees.Get(e => e.LastName == newEmployee.LastName && e.FirstName == newEmployee.FirstName && e.MiddleName == newEmployee.MiddleName
                    && e.EmployeeId != newEmployee.EmployeeId);
                employeeEmailCheck = unitOfWork.Employees.Get(e => e.Email == newEmployee.Email && e.EmployeeId != newEmployee.EmployeeId);
            }

            if (employeeNameCheck != null)
            {
                yield return new ValidationResult("Сотрудник с таким именем уже существует.");
            }
            if (employeeEmailCheck != null)
            {
                yield return new ValidationResult("Email", "Сотрудник с таким email уже существует.");
            }
        }

        public void CreateEmployee(Employee newEmployee)
        {
            unitOfWork.Employees.Create(newEmployee);
            SaveEmployee();
        }

        public void DeleteEmployee(int id)
        {
            var employee = unitOfWork.Employees.GetById(id);
            unitOfWork.Employees.Delete(employee);
            SaveEmployee();
        }

        public void EditEmployee(Employee employeeToEdit)
        {
            unitOfWork.Employees.Update(employeeToEdit);
            SaveEmployee();
        }

        public void SaveEmployee()
        {
            unitOfWork.Save();
        }

        // Search by surname or name only
        public IEnumerable<Employee> SearchEmployee(string employee)
        {
            var searchString = employee.ToLower();
            return unitOfWork.Employees.GetMany(e => e.LastName.ToLower().Contains(searchString) || e.FirstName.ToLower().Contains(searchString)).OrderBy(e => e.LastName);
        }
    }
}
