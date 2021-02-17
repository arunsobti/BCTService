using BCT.SwaggerAPI.Model;
using BCT.SwaggerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BCT.SwaggerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET api/customer  
        [HttpGet]
        public IEnumerable<Customer> GetCustomers() => _customerService.GetAll();

        // GET api/customer/id  
        [HttpGet("{id}", Name = nameof(GetCustomerById))]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = _customerService.Find(id);
            if (customer == null)
                return NotFound();
            else
                return new ObjectResult(customer);
        }

        // POST api/customer  
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null) return BadRequest();
            int retVal = _customerService.Add(customer);
            if (retVal > 0) return Ok(); else return NotFound();
        }
        // PUT api/customer/guid  
        [HttpPatch("{id}")]
        public IActionResult PatchCustomer(int id, [FromBody] Customer customer)
        {
            //if (customer == null || id != customer.Id) return BadRequest();
            if (_customerService.Find(id) == null) return NotFound();
            int retVal = _customerService.Update(customer, id);
            if (retVal > 0) return Ok(); else return NotFound();
        }

        // DELETE api/customer/5  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _customerService.Remove(id);
            if (retVal > 0) return Ok(); else return NotFound();
        }


    }
}
