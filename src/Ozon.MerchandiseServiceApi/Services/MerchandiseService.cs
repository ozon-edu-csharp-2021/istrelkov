using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchandiseServiceApi.Services.Interfaces;

namespace Ozon.MerchandiseServiceApi.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task<IActionResult> GetAll(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}