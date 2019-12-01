using System;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Queries
{
    public class GetCustomerOrdersQuery : IRequest<CustomerOrdersResponse>
    {
        public Guid CustomerId { get; }
        
        public GetCustomerOrdersQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}