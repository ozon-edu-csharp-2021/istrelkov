using MediatR;

using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.Infrastructure.Queries.GetMerchOrders;
using Ozon.MerchApi.Domain.Infrastructure.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Infrastructure.Handlers.MerchOrderAggregate
{
    public class GetMerchOrdersQueryHandler : IRequestHandler<GetMerchOrdersQuery, MerchOrdersQueryResponse>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public GetMerchOrdersQueryHandler(IMerchOrderRepository stockItemRepository) => _merchOrderRepository = stockItemRepository;

        public async Task<MerchOrdersQueryResponse> Handle(GetMerchOrdersQuery request, CancellationToken cancellationToken)
        {
            List<MerchOrder> merchOrders = await _merchOrderRepository.FindByEmployeeIdAsync(request.EmployeeId, cancellationToken);
            MerchOrdersQueryResponse merchOrdersQueryResponse = new MerchOrdersQueryResponse() 
            {
                MerchOrders = merchOrders 
            };
            return merchOrdersQueryResponse;
        }
    }
}