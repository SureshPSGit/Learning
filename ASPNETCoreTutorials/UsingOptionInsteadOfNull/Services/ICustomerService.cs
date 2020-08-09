using System;
using System.Collections.Generic;
using LanguageExt;

namespace UsingOptionInsteadOfNull.Services
{
    public interface ICustomerService
    {
        Option<Customer> Get(Guid customerId);

        IEnumerable<Customer> GetAll();

        void Create(Customer customer);
    }
}
