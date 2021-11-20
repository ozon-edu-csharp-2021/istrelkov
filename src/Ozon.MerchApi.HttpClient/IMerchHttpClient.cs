using Ozon.MerchApi.HttpModels;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<IssueMerchResponse> IssueMerch(IssueMerchRequest issueMerchRequest, CancellationToken token);

        Task<GetMerchOrdersResponse> CheckWasIssuedMerch(GetMerchOrdersRequest checkWasIssuedMerchRequest,
            CancellationToken token);
    }
}