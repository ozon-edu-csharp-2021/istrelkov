using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate
{
    public interface ISkuPackRepository : IRepository<SkuPack>
    {
        Task<List<SkuPack>> CreateAsync(MerchOrder merchOrder, CancellationToken cancellationToken);
    }
}