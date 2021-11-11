using Ozon.MerchApi.HttpModels;
using Ozon.MerchApi.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public async Task<IssueMerchResponse> IssueMerch(long id, CancellationToken token)
        {
            return await Task.FromResult(new IssueMerchResponse());
        }

        public async Task<GetMerchOrdersResponse> GetMerchOrders(long id, CancellationToken token)
        {
            return await Task.FromResult(new GetMerchOrdersResponse());
        }
    }
}