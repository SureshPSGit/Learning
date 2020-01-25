using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersApi.Database;
using CustomersApi.Dtos;
using Dapper;

namespace CustomersApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public CustomerRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<CustomerDto>("select * from Customers");
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<CustomerDto>("select * from Customers where Id=@id", new { id = id.ToString() });
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto customer)
        {
            using var connection = await _dbConnectionFactory.CreateConnectionAsync();
            customer.Id = Guid.NewGuid().ToString();
            await connection.ExecuteAsync("Insert into Customers (Id, FullName) VALUES (@id, @name)", new {id = customer.Id, name = customer.FullName});
            return customer;
        }
    }
}