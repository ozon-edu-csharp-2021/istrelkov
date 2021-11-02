using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Models;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public async Task<IssueMerchResponse> IssueMerch(long id, CancellationToken token)
        {
            return await Task.FromResult(new IssueMerchResponse(id));
        }

        public async Task<CheckWasIssuedMerchResponse> CheckWasIssuedMerch(long id, CancellationToken token)
        {
            return await Task.FromResult(new CheckWasIssuedMerchResponse(id));
        }
    }
}