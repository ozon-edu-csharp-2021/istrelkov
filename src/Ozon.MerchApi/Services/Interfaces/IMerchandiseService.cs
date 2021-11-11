using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchApi.HttpModels;

namespace Ozon.MerchApi.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<IssueMerchResponse> IssueMerch(long id, CancellationToken token);

        Task<GetMerchOrdersResponse> GetMerchOrders(long id, CancellationToken token);
    }
}