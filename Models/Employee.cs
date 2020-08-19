using System;
using System.ComponentModel.DataAnnotations;

namespace ConserviceHRSite.Models
{
    public enum PermissionEnum
    {
        Guest,
        Employee,
        IT,
        Admin
    }
    public class Employee
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public int PositionID { get; set; }
        public Position Position { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public EmployeeStatus Status { get; set; }

        public ShiftType Shift { get; set; }

        public int? ManagerID { get; set; }
        public Employee Manager { get; set; }

        public String Photo { get; set; }

        public String Color { get; set; }

        
        public PermissionEnum Permission { get; set; }

    }

    
    
}
