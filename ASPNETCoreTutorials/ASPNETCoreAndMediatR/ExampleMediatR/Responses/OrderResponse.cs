using System;

namespace ExampleMediatR.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public ProductResponse Product { get; set; }

        public CustomerResponse Customer { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }
    }
}