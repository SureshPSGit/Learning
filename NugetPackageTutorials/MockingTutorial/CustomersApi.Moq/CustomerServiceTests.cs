using System;
using System.Threading.Tasks;
using CustomersApi.Dtos;
using CustomersApi.Repositories;
using CustomersApi.Services;
using Moq;
using Xunit;

namespace CustomersApi.Moq
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _sut;
        private readonly Mock<ICustomerRepository> _customerRepoMock = new Mock<ICustomerRepository>();
        private readonly Mock<ILoggingService> _loggerMock = new Mock<ILoggingService>();

        public CustomerServiceTests()
        {
            _sut = new CustomerService(_customerRepoMock.Object, _loggerMock.Object);
        }
        
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerName = "Nick Chapsas";
            var customerDto = new CustomerDto
            {
                Id = customerId.ToString(),
                FullName = customerName
            };
            _customerRepoMock.Setup(x => x.GetByIdAsync(customerId))
                .ReturnsAsync(customerDto);
            
            // Act
            var customer = await _sut.GetByIdAsync(customerId);

            // Assert
            Assert.Equal(customerId, customer.Id);
            Assert.Equal(customerName, customer.FullName);
        }
        
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNothing_WhenCustomerDoesNotExist()
        {
            // Arrange
            _customerRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => null);
            
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
            var customerDto = new CustomerDto
            {
                Id = customerId.ToString(),
                FullName = customerName
            };
            _customerRepoMock.Setup(x => x.GetByIdAsync(customerId))
                .ReturnsAsync(customerDto);
            
            // Act
            var customer = await _sut.GetByIdAsync(customerId);
            
            // Assert
			_loggerMock.Verify(x => 
                x.LogInformation("Retrieved a customer with Id: {Id}", customerId), Times.Once);
            _loggerMock.Verify(x => 
                x.LogInformation("Unable to find a customer with Id: {Id}", customerId), Times.Never);
        }
    }
}