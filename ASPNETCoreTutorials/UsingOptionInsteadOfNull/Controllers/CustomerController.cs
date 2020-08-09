using System;
using Microsoft.AspNetCore.Mvc;
using UsingOptionInsteadOfNull.Services;

namespace UsingOptionInsteadOfNull.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("api/customers/{customerId}")]
        public IActionResult GetCustomer([FromRoute] string customerId)
        {
            if (!Guid.TryParse(customerId, out var customerIdGuid))
            {
                return NotFound();
            }

            var customer = _customerService.Get(customerIdGuid);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("api/customers")]
        public IActionResult GetCustomers()
        {
            return Ok(_customerService.GetAll());
        }
    }
}
