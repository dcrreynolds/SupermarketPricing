using SupermarketPricing.ItemSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupermarketPricing.Tests
{
    public class ByXGetYTests
    {
        [Fact]
        public void BuyXGetYSaleShouldProperlyAdjustPriceForFreeItem()
        {
            // Arrange
            var byXGetYSale = new ByXGetY(1, 1);
            var money = new Money(17.05);
            double result = 17.05;

            // Assert
            Assert.Equal(new Money(result), byXGetYSale.AdjustCost(money, 2));
        }

        [Fact]
        public void BuyXGetYSaleShouldProperlyAdjustPriceForQuantityNotMet()
        {
            // Arrange
            var byXGetYSale = new ByXGetY(2, 1);
            var money = new Money(17.05);
            double result = 17.05;

            // Assert
            Assert.Equal(new Money(result), byXGetYSale.AdjustCost(money, 1));
        }

        [Fact]
        public void BuyXGetYSaleShouldProperlyAdjustPriceForQuantityMetWithRemander()
        {
            // Arrange
            var byXGetYSale = new ByXGetY(2, 1);
            var money = new Money(17.05);
            double result = 17.05 * 2;

            // Assert
            Assert.Equal(new Money(result), byXGetYSale.AdjustCost(money, 3));
        }

        [Fact]
        public void BuyXGetYSaleShouldThrowIfBuyIsNotAbove0()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ByXGetY(0, 1));
        }

        [Fact]
        public void BuyXGetYSaleShouldThrowIfGetIsNotAbove0()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new ByXGetY(1, 0));
        }

        [Fact]
        public void PercentOffSaleShouldThrowWhenCostIsNull()
        {
            // Arrange
            var byXGetYSale = new ByXGetY(2, 1);

            // Assert
            Assert.Throws<ArgumentNullException>(() => byXGetYSale.AdjustCost(null, 1));
        }

        [Fact]
        public void PercentOffSaleShouldThrowWhenQuantityIsNegative()
        {
            // Arrange
            var byXGetYSale = new ByXGetY(2, 1);
            var money = new Money(17.05);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => byXGetYSale.AdjustCost(money, -1));
        }
    }
}
