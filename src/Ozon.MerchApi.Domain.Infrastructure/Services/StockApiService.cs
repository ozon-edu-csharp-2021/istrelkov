using Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate;
using Ozon.MerchApi.HttpModels;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.Infrastructure.Services
{
    public class StockApiService : IStockApiService
    {
        public Task<List<StockItemResponse>> GetAll(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Reserve(List<SkuPack> skuPacks, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}