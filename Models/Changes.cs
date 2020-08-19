using System;
using System.ComponentModel.DataAnnotations;

namespace ConserviceHRSite.Models
{
    public class Changes
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Type")]
        public ChangeType ChangeType { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
    }
}
