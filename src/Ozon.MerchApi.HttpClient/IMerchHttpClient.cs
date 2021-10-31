using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchApi.Models;

namespace Ozon.MerchApi.HttpClients
{
    public interface IMerchHttpClient
    {
        Task<IssueMerchResponse> IssueMerch(IssueMerchRequest issueMerchRequest, CancellationToken token);

        Task<CheckWasIssuedMerchResponse> CheckWasIssuedMerch(CheckWasIssuedMerchRequest checkWasIssuedMerchRequest,
            CancellationToken token);
    }
}