using System.Collections.Generic;
using ExampleMediatR.Dtos;
using ExampleMediatR.Responses;

namespace ExampleMediatR.Mapping
{
    public interface IMapper
    {
        List<CustomerResponse> MapCustomerDtosToCustomerResponses(List<CustomerDto> dtos);
        
        CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto);

        List<OrderResponse> MapOrderDtosToOrderResponses(List<OrderDto> customerOrders);
        
        OrderResponse MapOrderDtoToOrderResponse(OrderDto order);
    }
}