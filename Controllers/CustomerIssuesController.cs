using BCT.SwaggerAPI.Model;
using BCT.SwaggerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BCT.SwaggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerIssuesController : ControllerBase
    {

        private readonly ICustomerIssuesService _customerIssuesService;
        public CustomerIssuesController(ICustomerIssuesService customerIssuesService)
        {
            _customerIssuesService = customerIssuesService;
        }
        // GET api/customer  
        [HttpGet]
        public IEnumerable<CustomerIssues> GetCustomerIssues() => _customerIssuesService.GetAll();

        // GET api/customer/id  
        [HttpGet("{id}", Name = nameof(GetCustomerIssuesById))]
        public IActionResult GetCustomerIssuesById(int id)
        {
            CustomerIssues customerIssues = _customerIssuesService.Find(id);
            if (customerIssues == null)
                return NotFound();
            else
                return new ObjectResult(customerIssues);
        }

        // POST api/customer  
        [HttpPost]
        public IActionResult PostCustomerIssues([FromBody] CustomerIssues customerIssues)
        {
            if (customerIssues == null) return BadRequest();
            int retVal = _customerIssuesService.Add(customerIssues);
            if (retVal > 0) return Ok(); else return NotFound();
        }
        // PUT api/customer/guid  
        [HttpPatch("{id}")]
        public IActionResult PatchCustomerIssues(int id, [FromBody] CustomerIssues customerIssues)
        {
            //if (customer == null || id != customer.Id) return BadRequest();
            if (_customerIssuesService.Find(id) == null) return NotFound();
            int retVal = _customerIssuesService.Update(customerIssues, id);
            if (retVal > 0) return Ok(); else return NotFound();
        }

        // DELETE api/customer/5  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _customerIssuesService.Remove(id);
            if (retVal > 0) return Ok(); else return NotFound();
        }


    }
}
