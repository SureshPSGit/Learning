using System.Collections.Generic;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
    {
        
    }
}