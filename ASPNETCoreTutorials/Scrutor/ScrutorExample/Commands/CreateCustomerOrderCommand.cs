using System;
using MediatR;
using ScrutorExample.Responses;

namespace ScrutorExample.Commands
{
    public class CreateCustomerOrderCommand : IRequest<OrderResponse>
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }
    }
}