using EmployeeManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.IServices
{
    public interface IRequestLeaveServices
    {
        IEnumerable<RequestLeave> GetLeaveDetails();
        RequestLeave GetLeaveDetailsById(string id);
        string AddLeave(RequestLeave leave);
        string UpdateLeave(RequestLeave leave);
        string DeleteLeave(string id);

    }
}
