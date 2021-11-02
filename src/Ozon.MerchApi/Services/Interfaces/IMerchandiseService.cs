using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Models;

namespace Ozon.MerchApi.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<IssueMerchResponse> IssueMerch(long id, CancellationToken token);
        Task<CheckWasIssuedMerchResponse> CheckWasIssuedMerch(long id, CancellationToken token);
    }
}