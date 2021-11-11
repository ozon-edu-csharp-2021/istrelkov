using Ozon.MerchApi.Domain.AggregationModels.Enumerations;
using Ozon.MerchApi.Domain.AggregationModels.ItemPackAggregate;
using Ozon.MerchApi.Domain.Models;

using System.Collections.Generic;

namespace Ozon.MerchApi.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchPack : Entity
    {
        public IReadOnlyList<ItemPack> ItemPackCollection { get; }

        public MerchPackType Type { get; }

        public MerchPack(MerchPackType type, IReadOnlyList<ItemPack> itemPackCollection)
        {
            Type = type;
            ItemPackCollection = itemPackCollection;
        }
    }
}