using SibersTest.BLL.Infrastructure;
using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void CreateEmployee(Employee newEmployee);
        void EditEmployee(Employee employeeToEdit);
        void DeleteEmployee(int id);
        void SaveEmployee();
        IEnumerable<ValidationResult> CanAddEmployee(Employee newEmployee);
        IEnumerable<Employee> SearchEmployee(string employee);
    }
}
