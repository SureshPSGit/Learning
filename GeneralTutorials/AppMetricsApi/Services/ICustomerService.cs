using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppMetricsApi.Domain;

namespace AppMetricsApi.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();

        Task<Customer> CreateAsync(Customer customer);
        
        Task<Customer> GetByIdAsync(Guid customerId);
    }
}