using System.Collections.Generic;

namespace Ozon.MerchApi.HttpModels
{
    public sealed class GetMerchOrdersResponse
    {
        public IEnumerable<MerchOrderViewModel> MerchOrders { get; set; }
    }
}