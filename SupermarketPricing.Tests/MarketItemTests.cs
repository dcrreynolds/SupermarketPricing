using Moq;
using SupermarketPricing.ItemSales;
using System;
using Xunit;

namespace SupermarketPricing.Tests
{
    public class MarketItemTests
    {
        [Fact]
        public void MarketItemShoudCalculatePriceCorrectlyWithNoSale()
        {
            // Arrange
            var marketItem = new MarketItem(new Money(10.49), "Mahatma Basmati Rice");

            // Assert
            Assert.Equal(new Money(52.45), marketItem.GetPrice(5));
        }

        [Fact]
        public void MarketItemShoudThrowErrorWithNullName()
        {
            // Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new MarketItem(new Money(10.49), null));
        }

        [Fact]
        public void MarketItemShoudThrowErrorWithEmptyName()
        {
            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new MarketItem(new Money(10.49), ""));
        }

        [Fact]
        public void MarketItemShoudThrowErrorWhenItemCostIsNegative()
        {
            // Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new MarketItem(new Money(-1), "Pasta"));
        }

        [Fact]
        public void MarketItemShoudThrowErrorWhenItemCostIsNull()
        {
            // Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new MarketItem(null, "Pasta"));
        }

        [Fact]
        public void MarketItemShoudApplySales()
        {
            // Arrange
            var zeroMoney = new Money(0);
            var saleStub = new Mock<ISale>();

            saleStub
                .Setup(x => x.AdjustCost(zeroMoney, 1))
                .Returns(zeroMoney);

            // Act
            var marketItm = new MarketItem(zeroMoney, "Pasta", saleStub.Object);

            // Assert
            Assert.Equal(zeroMoney, marketItm.GetPrice(1));
        }
    }
}
