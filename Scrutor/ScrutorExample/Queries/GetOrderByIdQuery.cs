using System;
using MediatR;
using ScrutorExample.Responses;

namespace ScrutorExample.Queries
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