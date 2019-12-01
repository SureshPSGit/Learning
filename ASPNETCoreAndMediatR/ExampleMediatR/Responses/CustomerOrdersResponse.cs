using System;
using System.Collections.Generic;

namespace ExampleMediatR.Responses
{
    public class CustomerOrdersResponse
    {
        public Guid CustomerId { get; set; }
        
        public List<OrderResponse> Orders { get; set; }
    }
}