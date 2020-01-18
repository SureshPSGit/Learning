using System.Threading;
using System.Threading.Tasks;
using ExampleMediatR.Mapping;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Handlers
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