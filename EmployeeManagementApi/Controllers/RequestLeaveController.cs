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
    public class RequestLeaveController : Controller
    {
        private readonly IRequestLeaveServices requestLeaveServices;
        public RequestLeaveController(IRequestLeaveServices requestLeave)
        {
            requestLeaveServices = requestLeave;
        }


        [HttpGet("GetLeaveDetails")]

        public IActionResult GetLeaveDetails()
        {
            var record = requestLeaveServices.GetLeaveDetails();
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
        public IActionResult GetLeaveDetailsById(string id)
        {
            var record = requestLeaveServices.GetLeaveDetailsById(id);
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

        public IActionResult AddLeave(RequestLeave leave)
        {
            var status = requestLeaveServices.AddLeave(leave);
            if (status == "1")
            {
                return Ok(new { message = "success" });
            }
            else
            {
                return BadRequest(status);
            }

        }

        [HttpPut("UpdateLeave")]

        public IActionResult UpdateLeave(RequestLeave leave)
        {
            var status = requestLeaveServices.UpdateLeave(leave);
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
        public IActionResult DeleteLeave(string id)
        {
            var status = requestLeaveServices.DeleteLeave(id);
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
