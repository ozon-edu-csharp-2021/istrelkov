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
        [Route("api/merchandise/{id}/issue")]
        public async Task<IActionResult> GetMerch(int id, CancellationToken token)
        {
            var response = await _service.IssueMerch(id, token);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/merchandise/{id}/issue-info")]
        public async Task<IActionResult> GetInfo(int id, CancellationToken token)
        {
            var response = await _service.CheckWasIssuedMerch(id, token);
            return Ok(response);
        }
    }
}