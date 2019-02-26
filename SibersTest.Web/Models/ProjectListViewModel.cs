using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTest.Web.Models
{
    public class ProjectListViewModel
    {
        public IEnumerable<ProjectViewModel> ProjectsViewModel;
        public IEnumerable<SelectListItem> SortBy { get; set; }
        public IEnumerable<SelectListItem> FilterByPriority { get; set; }
        public DateTime? FilterByDate1;
        public DateTime? FilterByDate2;

        public ProjectListViewModel(string selectedFilter, string selectedSort, string filterByDate1, string filterByDate2)
        {
            FilterByPriority = new SelectList(new[]{
                       new SelectListItem{ Text="All", Value="All"},
                       new SelectListItem{ Text="1", Value="1"},
                       new SelectListItem{ Text="2", Value="2"},
                       new SelectListItem{ Text="3", Value="3"}
                       }, "Text", "Value", selectedFilter);

            SortBy = new SelectList(new[]{
                       new SelectListItem{ Text="Name", Value="Name"},
                       new SelectListItem{ Text="Start Date", Value="StartDate"},
                       new SelectListItem{ Text="End Date", Value="EndDate"},
                       new SelectListItem{ Text="Priority", Value= "Priority" }
                       }, "Value", "Text", selectedSort);
            
            if (filterByDate1 != null)
                FilterByDate1 = DateTime.Parse(filterByDate1);
            if (filterByDate2 != null)
                FilterByDate2 = DateTime.Parse(filterByDate2);
        }
    }
}