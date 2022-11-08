using EmployeeManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.IServices
{
    public interface IWorkingHourServices
    {
        IEnumerable<WorkingHour> GetWorkingHourDetails();
        WorkingHour GetWorkingHourDetailsById(string id);
        string AddWorkingHour(WorkingHour hour);
        string UpdateWorkingHour(WorkingHour hour);
        string DeleteWorkingHour(string id);

    }
}
