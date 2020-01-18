using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ScrutorExample.Dtos;

namespace ScrutorExample.Repositories.Cached
{
    public class CachedCustomersRepository : ICustomersRepository
    {
        private readonly ICustomersRepository _customersRepository; //CustomersRepository
        private readonly ConcurrentDictionary<Guid, CustomerDto> _cache = new ConcurrentDictionary<Guid, CustomerDto>();
        
        public CachedCustomersRepository(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        
        public async Task<CustomerDto> GetCustomerAsync(Guid customerId)
        {
            if (_cache.ContainsKey(customerId))
            {
                return _cache[customerId];
            }

            var customer = await _customersRepository.GetCustomerAsync(customerId);
            _cache.TryAdd(customerId, customer);
            return customer;
        }
    }
}