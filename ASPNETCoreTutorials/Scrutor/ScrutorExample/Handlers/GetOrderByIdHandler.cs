using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ScrutorExample.Mapping;
using ScrutorExample.Queries;
using ScrutorExample.Repositories;
using ScrutorExample.Responses;

namespace ScrutorExample.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetOrderAsync(request.OrderId);
            return order == null ? null : _mapper.MapOrderDtoToOrderResponse(order);
        }
    }
}