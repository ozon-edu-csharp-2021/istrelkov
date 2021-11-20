using MediatR;
using Ozon.MerchApi.Domain.Infrastructure.ResponseModels;

namespace Ozon.MerchApi.Domain.Infrastructure.Queries.GetMerchOrders
{
    public class GetMerchOrdersQuery : IRequest<MerchOrdersQueryResponse>
    {
        public long EmployeeId { get; set; }
    }
}