using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.Infrastructure.Queries.GetMerchOrders;
using Ozon.MerchApi.Domain.Infrastructure.ResponseModels;
using Ozon.MerchApi.HttpModels;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private IMerchandiseService _service;
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchandiseService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/merchandise/{id}/issue")]
        public async Task<IActionResult> GetMerch(int id, CancellationToken token)
        {
            var response = await _service.IssueMerch(id, token);
            return Ok(response);
        }

        [HttpPost]
        [Route("api/merchandise/issue-info")]
        public async Task<IActionResult> GetInfo(IssueMerchRequest request, CancellationToken token)
        {
            GetMerchOrdersQuery query = new() { EmployeeId = request.EmployeeId };

            MerchOrdersQueryResponse queryResponse  = await _mediator.Send(query, token);

            GetMerchOrdersResponse response = new()
            {
                MerchOrders = new List<MerchOrderViewModel>()
            };

            foreach (MerchOrder merchOrder in queryResponse.MerchOrders)
            {
                response.MerchOrders.Add(new MerchOrderViewModel()
                {
                    DoneAt = merchOrder.DoneAt.Value,
                    RequestType = merchOrder.RequestType.Name,
                    EmployeeId = merchOrder.EmployeeId,
                    ReserveAt = merchOrder.ReserveAt.Value,
                    Status = merchOrder.Status.Name,
                    Type = merchOrder.Type.Name,
                });
            }

            return Ok(response);
        }
    }
}