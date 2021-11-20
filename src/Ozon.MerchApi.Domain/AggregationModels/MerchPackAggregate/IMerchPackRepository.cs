using Ozon.MerchApi.Domain.AggregationModels.Enumerations;
using Ozon.MerchApi.Domain.Contracts;

using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.AggregationModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPack>
    {
        Task<MerchPack> FindByTypeAsync(MerchPackType merchPackType, CancellationToken cancellationToken);
    }
}