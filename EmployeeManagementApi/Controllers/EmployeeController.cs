using EmployeeManagementApi.Core.IServices;
using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using MobileAppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices employee)
        {
            employeeServices = employee;
        }


        [HttpGet("GetDetails")]

        public IActionResult GetDetails()
        {
            var record = employeeServices.GetDetails();
            if (record == null)
            {
                return BadRequest("No Records Found");
            }
            else
            {
                return Ok(record);

            }
        }
        [HttpGet("{id}")]
        public IActionResult GetDetailsById(string id)
        {
            var record = employeeServices.GetDetailsById(id);
            if(record==null)
            {
                return BadRequest("Record not Found");
            }
            else
            {
                return Ok(record);

            }
            
        }



        [HttpPost("AddEmployee")]

        public IActionResult AddEmployee(Employee employee)
        {
            var status = employeeServices.AddEmployee(employee);
            if(status=="1")
            {
                return Ok(new { message = "success" });
            }
            else
            {
                return BadRequest(status);
            }
            
        }

        [HttpPut("UpdateEmployee")]

        public IActionResult UpdateEmployee(Employee employee)
        {
            var status=employeeServices.UpdateEmployee(employee);
            if (status == "1")
            {
                return Ok("Updated Successfully");
            }
            else
            {
                return BadRequest(status);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            var status= employeeServices.DeleteEmployee(id);
            if(status=="1")
            {
                return Ok("Record Deleted Successfully");
            }
            else
            {
                return BadRequest(status);
            }
        }




        [HttpPost("signin")]
        public IActionResult signin(LoginDTO loginDTO)
        {
            var status1 = employeeServices.signin(loginDTO);
            if (status1 == null)
            {
                return BadRequest(new { message = "Login Failed" });


            }
            else
            {

                return Ok(new { message = "success" });
            }

        }



    }
}
