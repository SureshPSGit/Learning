using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersApi.Domain;

namespace CustomersApi.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();

        Task<Customer> CreateAsync(Customer customer);
        
        Task<Customer> GetByIdAsync(Guid customerId);
    }
}