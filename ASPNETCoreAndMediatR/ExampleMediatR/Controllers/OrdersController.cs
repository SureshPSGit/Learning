using System;
using System.Threading.Tasks;
using ExampleMediatR.Commands;
using ExampleMediatR.Mapping;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetOrder", new { orderId = result.Id }, result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var query = new GetOrderByIdQuery(orderId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}