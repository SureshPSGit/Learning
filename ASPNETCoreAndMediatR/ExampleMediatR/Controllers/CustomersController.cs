using System;
using System.Linq;
using System.Threading.Tasks;
using ExampleMediatR.Mapping;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CustomersController(ICustomersRepository customersRepository,
            IOrdersRepository ordersRepository, IMapper mapper, IMediator mediator)
        {
            _customersRepository = customersRepository;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId)
        {
            var query = new GetCustomerOrdersQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}