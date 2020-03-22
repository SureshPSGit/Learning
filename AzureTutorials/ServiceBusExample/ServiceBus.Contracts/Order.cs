using System;

namespace ServiceBus.Contracts
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ItemName { get; set; }
    }
}