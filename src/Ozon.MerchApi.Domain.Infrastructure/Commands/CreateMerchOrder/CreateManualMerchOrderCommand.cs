using MediatR;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;

namespace Ozon.MerchApi.Domain.Infrastructure.Commands.CreateMerchOrder
{
    public record CreateManualMerchOrderCommand(long EmployeeId, int ClothingSize, int MerchPackId) : IRequest<MerchOrder>;    
}