using System;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public Guid CustomerId { get; }
        
        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}