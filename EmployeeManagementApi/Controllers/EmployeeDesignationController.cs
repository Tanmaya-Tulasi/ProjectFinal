using EmployeeManagementApi.Core.IServices;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeDesignationController : Controller
    {
        private readonly IEmployeeDesignationServices employeeDesignationServices;
        public EmployeeDesignationController(IEmployeeDesignationServices employee)
        {
            employeeDesignationServices = employee;
        }


        [HttpGet("GetDetails")]

        public IActionResult GetDetails()
        {
            var record = employeeDesignationServices.GetDetails();
            if (record == null)
            {
                return BadRequest("No Records Found");
            }
            else
            {
                return Ok(record);

            }
          
        }
        [HttpGet("GetDetailsByDesignation")]
        public IActionResult GetDetailsByDesignation(string designation)
        {
            var record = employeeDesignationServices.GetDetailsByDesignation(designation);
            if (record == null)
            {
                return BadRequest("Record not Found");
            }
            else
            {
                return Ok(record);

            }
   
        }



        [HttpPost]
       
        public IActionResult AddDesignation(EmployeeDesignation employeeDesignation)
        {
            var status = employeeDesignationServices.AddDesignation(employeeDesignation);
            if (status == "1")
            {
                return Ok("Designation Added successfully");
            }
            else
            {
                return BadRequest(status);
            }
  
        }
       
        [HttpPut("UpdateDesignation")]
       
        public IActionResult UpdateDesignation(EmployeeDesignation employeeDesignation)
        {
            var status = employeeDesignationServices.UpdateDesignation(employeeDesignation);
            if (status == "1")
            {
                return Ok("Updated Successfully");
            }
            else
            {
                return BadRequest(status);
            }

    
        }

        [HttpDelete]
        public IActionResult DeleteDesignation(string designation)
        {
            var status = employeeDesignationServices.DeleteDesignation(designation);
            if (status == "1")
            {
                return Ok("Record Deleted Successfully");
            }
            else
            {
                return BadRequest(status);
            }
   
        }

    }
}
