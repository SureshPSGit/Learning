using System;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.Counter;
using AppMetricsApi.Domain;
using AppMetricsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMetricsApi.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMetrics _metrics;
        
        public CustomersController(ICustomerService customerService, IMetrics metrics)
        {
            _customerService = customerService;
            _metrics = metrics;
        }

        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var createdCustomer = await _customerService.CreateAsync(customer);
            _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedCustomersCounter);
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