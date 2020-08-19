using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ConserviceHRSite.Models
{
    public class DepartmentViewModel
    {
        public List<Employee> Employees { get; set; }
        public SelectList Departments { get; set; }
        public string DepartmentGenre { get; set; }
        public string SearchString { get; set; }
    }
}
