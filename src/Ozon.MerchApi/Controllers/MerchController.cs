using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private IMerchandiseService _service;

        public MerchandiseController(IMerchandiseService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/merchandise/{id}/merch")]
        public async Task<IActionResult> GetMerch(int id, CancellationToken token)
        {
            var response = await _service.GetMerch(id, token);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/merchandise/{id}/info")]
        public async Task<IActionResult> GetInfo(int id, CancellationToken token)
        {
            var response = await _service.GetInfo(id, token);
            return Ok(response);
        }
    }
}