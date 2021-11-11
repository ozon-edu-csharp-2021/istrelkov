using System.Collections.Generic;

namespace Ozon.MerchApi.HttpModels
{
    public sealed class GetMerchOrdersResponse
    {
        public List<MerchOrderViewModel> MerchOrders { get; set; }
    }
}