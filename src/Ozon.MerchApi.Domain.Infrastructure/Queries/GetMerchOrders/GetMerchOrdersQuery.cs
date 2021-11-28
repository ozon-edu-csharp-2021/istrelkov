using MediatR;
using Ozon.MerchApi.Domain.Infrastructure.ResponseModels;

namespace Ozon.MerchApi.Domain.Infrastructure.Queries.GetMerchOrders
{
    public record GetMerchOrdersQuery(long EmployeeId) : IRequest<MerchOrdersQueryResponse>; 
}