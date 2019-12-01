using System;

namespace ExampleMediatR.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }
    }
}