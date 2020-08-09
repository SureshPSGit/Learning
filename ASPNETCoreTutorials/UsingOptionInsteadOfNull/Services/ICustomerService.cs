using System;
using System.Collections.Generic;

namespace UsingOptionInsteadOfNull.Services
{
    public interface ICustomerService
    {
        Customer Get(Guid customerId);

        IEnumerable<Customer> GetAll();

        void Create(Customer customer);
    }
}
