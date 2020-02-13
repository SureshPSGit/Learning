using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMetricsApi.Domain;
using AppMetricsApi.Dtos;
using AppMetricsApi.Repositories;

namespace AppMetricsApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoggingService _logger;

        public CustomerService(ICustomerRepository customerRepository, ILoggingService logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customerDtos = (await _customerRepository.GetAllAsync()).ToList();
            _logger.LogInformation("Retrieved {Count} customers", customerDtos.Count);
            return customerDtos.Select(MapDtoToDomain).ToList();
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var customerDto = new CustomerDto{FullName = customer.FullName};
            var createdCustomer = await _customerRepository.CreateAsync(customerDto);
            _logger.LogInformation("Created a new customer with Id: {Id}", createdCustomer.Id);
            return MapDtoToDomain(createdCustomer);
        }

        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            
            if (customer == null)
            {
                _logger.LogInformation("Unable to find a customer with Id: {Id}", customerId);
                return null;
            }
            
            _logger.LogInformation("Retrieved a customer with Id: {Id}", customerId);
            return MapDtoToDomain(customer);
        }

        private Customer MapDtoToDomain(CustomerDto dto) => new Customer {Id = Guid.Parse(dto.Id), FullName = dto.FullName};
    }
}