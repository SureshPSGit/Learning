using System;
using System.Collections.Generic;
using LanguageExt;

namespace UsingOptionInsteadOfNull.Repositories
{
    public interface ICustomerRepository
    {
        Option<Customer> Get(Guid customerId);

        IEnumerable<Customer> GetAll();

        void Create(Customer customer);
    }
}
