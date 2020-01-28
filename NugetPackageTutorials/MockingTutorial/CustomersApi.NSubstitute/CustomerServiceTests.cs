using System;
using System.Threading.Tasks;
using CustomersApi.Dtos;
using CustomersApi.Repositories;
using CustomersApi.Services;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace CustomersApi.NSubstitute
{
    public class CustomerServiceTests
    {
        private readonly ICustomerService _sut;
        private readonly ICustomerRepository _customerRepository = Substitute.For<ICustomerRepository>();
        private readonly ILoggingService _logging = Substitute.For<ILoggingService>();
        
        public CustomerServiceTests()
        {
            _sut = new CustomerService(_customerRepository, _logging);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerName = "Nick Chapsas";
            var customerDto = new CustomerDto {Id = customerId.ToString(), FullName = customerName};

            _customerRepository.GetByIdAsync(customerId).Returns(customerDto);
            
            // Act
            var customer = await _sut.GetByIdAsync(customerId);

            // Assert
            Assert.Equal(customerId, customer.Id);
            Assert.Equal(customerName, customer.FullName);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenCustomerDoesNotExist()
        {
            // Arrange
            _customerRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

            // Act
            var customer = await _sut.GetByIdAsync(Guid.NewGuid());
            
            // Assert
            Assert.Null(customer);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldLogAppropriateMessage_WhenCustomerExists()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerName = "Nick Chapsas";
            var customerDto = new CustomerDto {Id = customerId.ToString(), FullName = customerName};
            _customerRepository.GetByIdAsync(customerId).Returns(customerDto);
            
            // Act
            await _sut.GetByIdAsync(customerId);

            // Assert
            _logging.Received(1).LogInformation("Retrieved a customer with Id: {Id}", customerId);
            _logging.DidNotReceive().LogInformation("Unable to find a customer with Id: {Id}", customerId);
        }
    }
}