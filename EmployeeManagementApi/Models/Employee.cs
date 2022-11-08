using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeManagementApi.Models
{
    public partial class Employee
    {
        public Employee()
        {
            RequestLeave = new HashSet<RequestLeave>();
            WorkingHour = new HashSet<WorkingHour>();
        }

        public string Empid { get; set; }
        public string Empname { get; set; }
        public int? Phone { get; set; }
        public string Address { get; set; }
        public string DesignationName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public virtual EmployeeDesignation DesignationNameNavigation { get; set; }
        public virtual ICollection<RequestLeave> RequestLeave { get; set; }
        public virtual ICollection<WorkingHour> WorkingHour { get; set; }
    }
}
