using System;
using System.Threading.Tasks;
using AppMetricsApi.Domain;
using AppMetricsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMetricsApi.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerService.CreateAsync(customer);
            return CreatedAtAction("GetCustomer", new { customerId = createdCustomer.Id}, createdCustomer);
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            return customer != null ? (IActionResult) Ok(customer) : NotFound();
        }
        
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var allCustomers = await _customerService.GetAllAsync();
            return Ok(allCustomers);
        }
    }
}