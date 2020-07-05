using System;

namespace RealisticDataGenerationWithBogus
{
    public class Order
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public BillingDetails BillingDetails { get; set; }
    }
    
    public class BillingDetails
    {
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }
    }
}