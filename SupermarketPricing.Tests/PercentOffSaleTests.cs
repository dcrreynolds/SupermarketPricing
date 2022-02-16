using SupermarketPricing.ItemSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupermarketPricing.Tests
{
    public class PercentOffSaleTests
    {
        [Fact]
        public void PercentOffSaleShouldProperlyAdjustPrice()
        {
            // Arrange
            var pctSale = new PercentOffSale(.75);
            var money = new Money(17.05);
            double result = 17.05 * .75 * 2;

            // Assert
            Assert.Equal(new Money(result), pctSale.AdjustCost(money, 2));
        }

        [Fact]
        public void PercentOffSaleShouldThrowIfNotAPercent()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new PercentOffSale(1.01));
        }

        [Fact]
        public void PercentOffSaleShouldThrowWhenCostIsNull()
        {
            // Arrange
            var pctSale = new PercentOffSale(.75);

            // Assert
            Assert.Throws<ArgumentNullException>(() => pctSale.AdjustCost(null, 1));
        }

        [Fact]
        public void PercentOffSaleShouldThrowWhenQuantityIsNegative()
        {
            // Arrange
            var pctSale = new PercentOffSale(.75);
            var money = new Money(17.05);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => pctSale.AdjustCost(money, -1));
        }
    }
}
