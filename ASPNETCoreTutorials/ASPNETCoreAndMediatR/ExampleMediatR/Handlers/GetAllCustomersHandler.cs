using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExampleMediatR.Mapping;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using ExampleMediatR.Responses;
using MediatR;

namespace ExampleMediatR.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customerDtos = await _customersRepository.GetCustomersAsync();
            return _mapper.MapCustomerDtosToCustomerResponses(customerDtos);
        }
    }
}