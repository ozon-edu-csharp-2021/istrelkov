using MediatR;

using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;

using System.Collections.Generic;

namespace Ozon.MerchApi.Domain.Infrastructure.Commands.GetMerchOrders
{
    public class GetMerchOrdersCommand : IRequest<List<MerchOrder>>
    {
        public long EmployeeId { get; set; }
    }
}