using Ozon.MerchApi.Domain.AggregationModels.ValueObjects;
using Ozon.MerchApi.Domain.Models;

namespace Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate
{
    public class SkuPack: Entity, IAggregationRoot
    {
        public Quantity Quantity { get; private set; }
        public Sku Sku { get; }

        public SkuPack(Sku sku, Quantity quantity)
        {
            Sku = sku;
            Quantity = quantity;
        }
    }
}