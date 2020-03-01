using System.Threading.Tasks;
using AzureKeyVaultExample.Models;
using Cosmonaut;
using Cosmonaut.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AzureKeyVaultExample.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ICosmosStore<Customer> _cosmosStore;
        
        public CustomersController(ICosmosStore<Customer> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> GetCustomer([FromRoute] string customerId)
        {
            var customer = await _cosmosStore.FindAsync(customerId, customerId);
            return customer == null ? (IActionResult) NotFound() : Ok(customer);
        }
        
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _cosmosStore.Query().ToListAsync());
        }
    }
}