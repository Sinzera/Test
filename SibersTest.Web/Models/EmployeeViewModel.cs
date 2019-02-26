using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTest.Web.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Некорректный Email адрес")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}