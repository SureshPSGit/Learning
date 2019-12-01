using System;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Commands
{
    public class CreateCustomerOrderCommand : IRequest<OrderResponse>
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }
    }
}