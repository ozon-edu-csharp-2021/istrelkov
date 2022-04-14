using Grpc.Core;
using Ozon.MerchApi.Grpc;
using System.Threading.Tasks;
using Ozon.MerchApi.Services.Interfaces;

namespace Ozon.MerchApi.GrpcServices
{
    public class MerchApiGrpsService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchApiGrpsService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<CheckWasIssuedMerchResponse> CheckWasIssuedMerch(CheckWasIssuedMerchRequest request,
            ServerCallContext context)
        {
            var response = await _merchandiseService.GetMerchOrders(request.EmployeeId, context.CancellationToken);

            return new CheckWasIssuedMerchResponse()
            {
            };
        }

        public override async Task<IssueMerchResponse> IssueMerch(IssueMerchRequest request, ServerCallContext context)
        {
            var response = await _merchandiseService.IssueMerch(request.EmployeeId, context.CancellationToken);
            return new IssueMerchResponse
            {
                EmployeeId = response.MerchOrder.EmployeeId,
            };
        }
    }
}