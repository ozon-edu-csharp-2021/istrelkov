using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using System.Collections.Generic;

namespace Ozon.MerchApi.Domain.Infrastructure.ResponseModels
{
    public class MerchOrdersQueryResponse
    {
        public List<MerchOrder> MerchOrders { get; set; }
    }
}
