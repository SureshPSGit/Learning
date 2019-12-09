using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ScrutorExample.Dtos;

namespace ScrutorExample.Repositories
{
    public interface ICustomersRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid customerId);
        
        Task<List<CustomerDto>> GetCustomersAsync();
    }
}