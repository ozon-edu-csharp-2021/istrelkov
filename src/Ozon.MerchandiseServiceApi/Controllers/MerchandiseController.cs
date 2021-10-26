using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchandiseServiceApi.Services.Interfaces;

namespace Ozon.MerchandiseServiceApi.Controllers
{
    [ApiController]
    [Route("api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController: ControllerBase
    {
        private IMerchandiseService _service;
        public MerchandiseController(IMerchandiseService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok("Ok");
        }

    }
}