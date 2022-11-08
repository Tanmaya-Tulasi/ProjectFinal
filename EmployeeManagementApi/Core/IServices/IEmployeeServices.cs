using EmployeeManagementApi.Models;
using MobileAppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.IServices
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetDetails();
        Employee GetDetailsById(string id);
        string AddEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(string id);

        string signin(LoginDTO loginDTO);

    }
}
