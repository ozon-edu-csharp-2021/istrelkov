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
    public class MerchandiseController : ControllerBase
    {
        private IMerchandiseService _service;
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchandiseService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet("get-merch-orders/{employeeId}")]
        public async Task<ActionResult<GetMerchOrdersResponse>> GetMerchOrders(int employeeId, CancellationToken token)
        {
            GetMerchOrdersQuery command = new()
            {
                EmployeeId = employeeId
            };

            MerchOrdersQueryResponse merchOrdersQueryResponse = await _mediator.Send(command, token);
            GetMerchOrdersResponse response = new()
            {
                MerchOrders = merchOrdersQueryResponse.MerchOrders.Map(entity => HttpModelsMapper.MerchOrderToViewModel(entity))
            };

            return Ok(response);
        }

        [HttpPost("issue-merch")]
        public async Task<ActionResult<IssueMerchResponse>> IssueMerch(IssueMerchRequest request, CancellationToken token)
        {
            CreateManualMerchOrderCommand command = new()
            {
                EmployeeId = request.EmployeeId,
                ClothingSize = request.ClothingSize,
                MerchPackId = request.MerchPackId,
            };

            MerchOrder merchOrder = await _mediator.Send(command, token);
            IssueMerchResponse response = new()
            {
                MerchOrder = HttpModelsMapper.MerchOrderToViewModel(merchOrder)
            };

            return Ok(response);
        }
    }
}