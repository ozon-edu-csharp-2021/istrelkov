using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Models;

namespace Ozon.MerchApi.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<MerchResponse> GetMerch(int id, CancellationToken token);

        Task<MerchResponse> GetInfo(int id, CancellationToken token);
    }
}