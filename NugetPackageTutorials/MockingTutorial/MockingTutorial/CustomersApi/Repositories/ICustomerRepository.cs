using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersApi.Dtos;

namespace CustomersApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        
        Task<CustomerDto> GetByIdAsync(Guid id);

        Task<CustomerDto> CreateAsync(CustomerDto customer);
    }
}