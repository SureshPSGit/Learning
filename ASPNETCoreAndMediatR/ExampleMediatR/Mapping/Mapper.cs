using System;
using System.Collections.Generic;
using System.Linq;
using ExampleMediatR.Dtos;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;

namespace ExampleMediatR.Mapping
{
    // This mapper has non-mapping logic in it
    // It's a bad mapper. Don't use this bad mapper
    public class Mapper : IMapper
    {
        private readonly ICustomersRepository _customersRepository;

        public Mapper(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public List<CustomerResponse> MapCustomerDtosToCustomerResponses(List<CustomerDto> dtos)
        {
            return dtos.Select(x => new CustomerResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto)
        {
            return new CustomerResponse {Id = customerDto.Id, Name = customerDto.Name};
        }

        public List<OrderResponse> MapOrderDtosToOrderResponses(List<OrderDto> customerOrders)
        {
            return customerOrders.Select(x => new OrderResponse
            {
                Id = x.Id,
                Customer = MapCustomerDtoToCustomerResponse(_customersRepository.GetCustomerAsync(x.CustomerId).GetAwaiter().GetResult()),
                Product = new ProductResponse
                {
                    Id = x.ProductId,
                    Name = "Amazing Product",
                    Price = 6.99m,
                    ReleaseDate = DateTime.UtcNow
                },
                Delivered = x.Delivered,
                DeliveryDate = x.DeliveryDate
            }).ToList();
        }

        public OrderResponse MapOrderDtoToOrderResponse(OrderDto order)
        {
            return new OrderResponse
            {
                Id = order.Id,
                Customer = MapCustomerDtoToCustomerResponse(_customersRepository.GetCustomerAsync(order.CustomerId).GetAwaiter().GetResult()),
                Product = new ProductResponse
                {
                    Id = order.ProductId,
                    Name = "Amazing Product",
                    Price = 6.99m,
                    ReleaseDate = DateTime.UtcNow
                },
                Delivered = order.Delivered,
                DeliveryDate = order.DeliveryDate
            };
        }
    }
}