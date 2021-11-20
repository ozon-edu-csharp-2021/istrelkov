using MediatR;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;

namespace Ozon.MerchApi.Domain.Infrastructure.Commands.CreateMerchOrder
{
    public class CreateManualMerchOrderCommand : IRequest<MerchOrder>
    {
        public long EmployeeId { get; set; }
        public int ClothingSize { get; init; }
        public int MerchPackId { get; set; }
    }
}