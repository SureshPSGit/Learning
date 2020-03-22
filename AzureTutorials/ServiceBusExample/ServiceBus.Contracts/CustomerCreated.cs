using System;

namespace ServiceBus.Contracts
{
    public class CustomerCreated
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}