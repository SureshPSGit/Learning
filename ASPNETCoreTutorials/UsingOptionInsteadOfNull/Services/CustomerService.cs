using System;
using System.Collections.Generic;
using LanguageExt;
using UsingOptionInsteadOfNull.Repositories;

namespace UsingOptionInsteadOfNull.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Option<Customer> Get(Guid customerId)
        {
            // Business logic stuff here

            return _customerRepository.Get(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Create(Customer customer)
        {
            // Business logic stuff here

            _customerRepository.Create(customer);
        }
    }
}
