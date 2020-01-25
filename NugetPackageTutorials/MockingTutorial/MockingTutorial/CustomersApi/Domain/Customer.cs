using System;

namespace CustomersApi.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
    }
}