using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleMediatR.Dtos;

namespace ExampleMediatR.Repositories
{
    public interface ICustomersRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid customerId);
        
        Task<List<CustomerDto>> GetCustomersAsync();
    }
}