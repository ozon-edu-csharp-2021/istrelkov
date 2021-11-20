using Ozon.MerchApi.Domain.AggregationModels.ItemPackAggregate;
using Ozon.MerchApi.Domain.AggregationModels.ValueObjects;
using Ozon.MerchApi.Domain.Exceptions;

using Xunit;

namespace Ozon.MerchApi.Domain.Tests
{
    public class ItemPackTests
    {
        [Fact]
        public void CreateNegativeQuantitySuccess()
        {
            int value = -1;

            Assert.Throws<NegativeValueException>(() =>
            {
                ItemPack stockItem = new(
                    new StockItem(45132),
                    new Quantity(value));
            });
        }

        [Fact]
        public void DecreaseQuantityNegativeAndZeroValueSuccess()
        {
            ItemPack stockItem = new(
                new StockItem(45132),
                new Quantity(851));

            int value = -1;
            Assert.Throws<NegativeOrZeroValueException>(() => stockItem.DecreaseQuantity(value));

            value = 0;
            Assert.Throws<NegativeOrZeroValueException>(() => stockItem.DecreaseQuantity(value));
        }

        [Fact]
        public void IncreaseQuantityNegativeAndZeroValueSuccess()
        {
            ItemPack stockItem = new(
                new StockItem(45132),
                new Quantity(851));

            int value = -1;
            Assert.Throws<NegativeOrZeroValueException>(() => stockItem.IncreaseQuantity(value));

            value = 0;
            Assert.Throws<NegativeOrZeroValueException>(() => stockItem.IncreaseQuantity(value));
        }
    }
}