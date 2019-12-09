using System.Collections.Generic;
using ScrutorExample.Dtos;
using ScrutorExample.Responses;

namespace ScrutorExample.Mapping
{
    public interface IMapper
    {
        List<CustomerResponse> MapCustomerDtosToCustomerResponses(List<CustomerDto> dtos);
        
        CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto);

        List<OrderResponse> MapOrderDtosToOrderResponses(List<OrderDto> customerOrders);
        
        OrderResponse MapOrderDtoToOrderResponse(OrderDto order);
    }
}