using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using LanguageExt;
using LanguageExt.SomeHelp;

namespace UsingOptionInsteadOfNull.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ConcurrentDictionary<Guid, Customer> _customers = new ConcurrentDictionary<Guid, Customer>(new Dictionary<Guid, Customer>
        {
            {Guid.Parse("67C60179-90D8-4C89-8423-4F68F6A9A9C5"), new Customer
            {
                Id = Guid.Parse("67C60179-90D8-4C89-8423-4F68F6A9A9C5"),
                FullName = "Nick Chapsas"
            }}
        });

        public Option<Customer> Get(Guid customerId)
        {
            var found = _customers.TryGetValue(customerId, out var customer);
            return found ? customer.ToSome() : Option<Customer>.None;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers.Values;
        }

        public void Create(Customer customer)
        {
            _customers.TryAdd(customer.Id, customer);
        }
    }
}
