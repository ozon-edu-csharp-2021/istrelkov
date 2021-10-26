using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ozon.MerchandiseServiceApi.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<IActionResult> GetAll(CancellationToken token);
    }
}