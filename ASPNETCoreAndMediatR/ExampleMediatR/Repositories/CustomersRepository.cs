using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleMediatR.Dtos;

namespace ExampleMediatR.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<CustomerDto> _customers = new List<CustomerDto>
        {
            new CustomerDto{Id = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"), Name = "Nick Chapsas"},
            new CustomerDto{Id = Guid.Parse("fc7cdfc4-f407-4955-acbe-98c666ee51a2"), Name = "John Doe"},
            new CustomerDto{Id = Guid.Parse("a46ac8f4-2ecd-43bf-a9e6-e557b9af1d6e"), Name = "Sam McRandom"}
        };
        
        public Task<CustomerDto> GetCustomerAsync(Guid customerId)
        {
            return Task.FromResult(_customers.SingleOrDefault(x => x.Id == customerId));
        }

        public Task<List<CustomerDto>> GetCustomersAsync()
        {
            return Task.FromResult(_customers);
        }
    }
}