using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.Infrastructure.Commands.CreateMerchOrder;
using Ozon.MerchApi.Domain.Infrastructure.Queries.GetMerchOrders;
using Ozon.MerchApi.Domain.Infrastructure.ResponseModels;
using Ozon.MerchApi.HttpModels;
using Ozon.MerchApi.HttpModels.Helpers;
using Ozon.MerchApi.Infrastructure.Extensions;
using Ozon.MerchApi.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Ozon.MerchApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/merchandise")]
    public class MerchandiseController : ControllerBase
    {
        private IMerchandiseService _service;
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchandiseService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet("employee/{employeeId}/orders")]
        public async Task<ActionResult<GetMerchOrdersResponse>> GetMerchOrders(int employeeId, CancellationToken token)
        {
            GetMerchOrdersQuery command = new(employeeId);
      
            MerchOrdersQueryResponse merchOrdersQueryResponse = await _mediator.Send(command, token);
            GetMerchOrdersResponse response = new()
            {
                MerchOrders = merchOrdersQueryResponse.MerchOrders.Map(HttpModelsMapper.MerchOrderToViewModel)
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<IssueMerchResponse>> IssueMerch(IssueMerchRequest request, CancellationToken token)
        {
            CreateManualMerchOrderCommand command = new(request.EmployeeId, request.ClothingSize, request.MerchPackId);

            MerchOrder merchOrder = await _mediator.Send(command, token);
            IssueMerchResponse response = new()
            {
                MerchOrder = HttpModelsMapper.MerchOrderToViewModel(merchOrder)
            };

            return Ok(response);
        }
    }
}