using Ozon.MerchApi.Domain.Contracts;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate
{
    public interface IMerchOrderRepository : IRepository<MerchOrder>
    {
        Task<MerchOrder> CreateAsync(MerchOrder itemToCreate, CancellationToken cancellationToken);
        Task<List<MerchOrder>> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken);
        Task<List<MerchOrder>> FindIssuedMerchAsync(long employeeId, int merchPackId, CancellationToken cancellationToken);

    }
}