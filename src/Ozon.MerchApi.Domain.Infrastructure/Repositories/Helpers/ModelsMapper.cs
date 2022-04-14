using Ozon.MerchApi.Domain.AggregationModels.Enumerations;
using Ozon.MerchApi.Domain.AggregationModels.ItemPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.MerchOrderAggregate;
using Ozon.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.SkuPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.ValueObjects;
using Ozon.MerchApi.Infrastructure.Extensions;

using System.Linq;

namespace Ozon.MerchApi.Domain.Infrastructure.Repositories.Helpers
{
    public static class ModelsMapper
    {
        public static ItemPack ItemPackModelToEntity(Models.ItemPack model)
        {
            return model is null
                ? null
                : (new(
                new StockItem(model.StockItemId),
                new Quantity(model.Quantity)));
        }

        public static MerchOrder MerchOrderModelToEntity(Models.MerchOrder model)
        {
            return model is null
                ? null
                : (new(
                model.Id,
                new MerchPackType(model.PackTypeId, model.PackTypeName),
                new MerchOrderStatus(model.StatusId, model.StatusName),
                new MerchRequestType(model.RequestTypeId, model.RequestTypeName),
                new DateAt(model.InWorkAt),
                new DateAt(model.ReserveAt),
                new DateAt(model.DoneAt),
                model.EmployeeId,
                model.SkuPackCollection.Map(model => SkuPackModelToEntity(model)).ToList()));
        }

        public static MerchPack MerchPackModelToEntity(Models.MerchPack model)
        {
            return model is null
                ? null
                : (new(
                new MerchPackType(model.PackTypeId, model.PackTypeName),
                model.ItemPackCollection.Map(model => ItemPackModelToEntity(model)).ToList()));
        }

        public static SkuPack SkuPackModelToEntity(Models.SkuPack model)
        {
            return model is null
                ? null
                : (new(
                new Sku(model.SkuId),
                new Quantity(model.Quantity)));
        }
    }
}