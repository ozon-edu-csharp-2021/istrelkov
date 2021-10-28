using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Models;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public async Task<MerchResponse> GetInfo(int id, CancellationToken token)
        {
            await Task.Yield();
            return new MerchResponse(id, true);
        }

        public async Task<MerchResponse> GetMerch(int id, CancellationToken token)
        {
            await Task.Yield();
            return new MerchResponse(id, true);
        }
    }
}