using System;

namespace ServiceBus.Contracts
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}