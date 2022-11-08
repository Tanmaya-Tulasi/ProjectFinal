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

    public class PaymentRulesController : Controller
    {
        private readonly IPaymentRulesServices paymentRulesServices;
        public PaymentRulesController(IPaymentRulesServices paymentRules)
        {
            paymentRulesServices = paymentRules;
        }


        [HttpGet("GetDetails")]

        public IActionResult GetDetails()
        {
            var record = paymentRulesServices.GetDetails();
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
        public IActionResult GetDetailsById(int id)
        {
            var record = paymentRulesServices.GetDetailsById(id);
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

        public IActionResult AddPaymentRule(PaymentRules paymentRules)
        {
            var status = paymentRulesServices.AddPaymentRule(paymentRules);
            if (status == "1")
            {
                return Ok(new { message = "success" });
            }
            else
            {
                return BadRequest(status);
            }
        }

        [HttpPut("UpdatePaymentRule")]

        public IActionResult UpdatePaymentRule(PaymentRules paymentRules)
        {
            var status = paymentRulesServices.UpdatePaymentRule(paymentRules);
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
        public IActionResult DeletePaymentRule(int id)
        {
            var status = paymentRulesServices.DeletePaymentRule(id);
            if(status == "1")
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
