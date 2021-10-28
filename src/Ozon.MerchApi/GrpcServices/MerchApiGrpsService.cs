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

        public override async Task<GetMerchResponse> GetMerch(GetMerchRequest request, ServerCallContext context)
        {
            var response = await _merchandiseService.GetMerch(request.EmloyeeId, context.CancellationToken);

            return new GetMerchResponse()
            {
                EmloyeeId = response.EmployeerId,
                IsIssued = response.IsIssued
            };
        }

        public override async Task<GetMerchResponse> GetInfo(GetMerchRequest request, ServerCallContext context)
        {
            var response = await _merchandiseService.GetMerch(request.EmloyeeId, context.CancellationToken);
            return new GetMerchResponse()
            {
                EmloyeeId = response.EmployeerId,
                IsIssued = response.IsIssued
            };
        }
    }
}