using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeManagementApi.Models
{
    public partial class RequestLeave
    {
        public int Sno { get; set; }
        public string RequestType { get; set; }
        public DateTime? StartDate { get; set; }
        public int? NoOfDays { get; set; }
        public string LeaveReason { get; set; }
        public string Empid { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
