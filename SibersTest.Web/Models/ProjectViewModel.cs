using SibersTest.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SibersTest.Web.Models
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(150)]
        [Display(Name = "Название проекта")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Заказчик")]
        public string CustomerCompany { get; set; }

        [StringLength(100)]
        [Display(Name = "Исполнитель")]
        public string PerformerCompany { get; set; }

        [Display(Name = "Руководитель")]
        public int? ManagerId { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата окончания")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Приоритет")]
        public byte Priority { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        public virtual Employee Manager { get; set; }
        [Display(Name = "Сотрудники")]
        public virtual ICollection<int> EmployeesId { get; set; } = new List<int>();
        public virtual ICollection<Employee> Employees { get; set; }
    }
}