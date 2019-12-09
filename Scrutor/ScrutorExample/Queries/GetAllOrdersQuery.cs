using System.Collections.Generic;
using MediatR;
using ScrutorExample.Responses;

namespace ScrutorExample.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
    {
        
    }
}