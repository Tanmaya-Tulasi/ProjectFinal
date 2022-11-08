using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeManagementApi.Models
{
    public partial class EmployeeDesignation
    {
        public EmployeeDesignation()
        {
            Employee = new HashSet<Employee>();
        }

        public string Designation { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
