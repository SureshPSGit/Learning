using System;
using System.Collections.Generic;

namespace UsingOptionInsteadOfNull.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid customerId);

        IEnumerable<Customer> GetAll();

        void Create(Customer customer);
    }
}
