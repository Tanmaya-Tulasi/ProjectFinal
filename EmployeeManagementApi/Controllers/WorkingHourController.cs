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

    public class WorkingHourController : Controller
    {
        private readonly IWorkingHourServices workingHourServices;
        public WorkingHourController(IWorkingHourServices workingHour)
        {
            workingHourServices = workingHour;
        }


        [HttpGet("GetWorkingHourDetails")]

        public IActionResult GetWorkingHourDetails()
        {
            var record = workingHourServices.GetWorkingHourDetails();
            if (record == null)
            {
                return BadRequest("No Records Found");
            }
            else
            {
                return Ok(record);

            }
        }
        [HttpGet("GetWorkingHourDetailsById")]
        public IActionResult GetWorkingHourDetailsById(string id)
        {
            var record = workingHourServices.GetWorkingHourDetailsById(id);
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

        public IActionResult AddWorkingHour(WorkingHour hour)
        {
            var status = workingHourServices.AddWorkingHour(hour);
            if (status == "1")
            {
                return Ok("Employee Working Hours Added successfully");
            }
            else
            {
                return BadRequest(status);
            }

        }

        [HttpPut("UpdateWorkingHour")]

        public IActionResult UpdateWorkingHour(WorkingHour hour)
        {

            var status = workingHourServices.UpdateWorkingHour(hour);
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
        public IActionResult DeleteWorkingHour(string id)
        {
            var status = workingHourServices.DeleteWorkingHour(id);
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
