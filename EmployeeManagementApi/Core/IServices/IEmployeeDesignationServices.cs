using EmployeeManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.IServices
{
    public interface IEmployeeDesignationServices
    {
        IEnumerable<EmployeeDesignation> GetDetails();
        EmployeeDesignation GetDetailsByDesignation(string designation);
        string AddDesignation(EmployeeDesignation employeeDesignation);
        string UpdateDesignation(EmployeeDesignation employeeDesignation);
        string DeleteDesignation(string designation);


    }
}
