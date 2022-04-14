using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;

namespace Ozon.MerchApi.HttpModels.Helpers
{
    public static class HttpModelsMapper
    {
        public static MerchOrderViewModel MerchOrderToViewModel(MerchOrder merchOrder)
        {
            return new MerchOrderViewModel()
            {
                DoneAt = merchOrder.DoneAt.Value,
                RequestType = merchOrder.RequestType.Name,
                EmployeeId = merchOrder.EmployeeId,                
                ReserveAt = merchOrder.ReserveAt.Value,
                InWorkAt = merchOrder.InWorkAt.Value,
                Status = merchOrder.Status.Name,
                Type = merchOrder.PackType.Name,
            };
        }
    }
}
