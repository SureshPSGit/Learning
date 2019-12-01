using System;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public Guid OrderId { get; }
        
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}