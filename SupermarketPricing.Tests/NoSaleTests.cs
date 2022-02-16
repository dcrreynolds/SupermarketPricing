using SupermarketPricing.ItemSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupermarketPricing.Tests
{
    public class NoSaleTests
    {
        [Fact]
        public void NoSaleShouldNotAdjustPrice()
        {
            // Arrange
            var noSale = new NoSale();
            var money = new Money(17.05);
            double result = 17.05 * 2;

            // Assert
            Assert.Equal(new Money(result), noSale.AdjustCost(money, 2));
        }

        [Fact]
        public void NoSaleShouldThrowWhenCostIsNull()
        {
            // Arrange
            var noSale = new NoSale();

            // Assert
            Assert.Throws<ArgumentNullException>(() => noSale.AdjustCost(null, 1));
        }

        [Fact]
        public void NoSaleShouldThrowWhenQuantityIsNegative()
        {
            // Arrange
            var noSale = new NoSale();
            var money = new Money(17.05);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => noSale.AdjustCost(money, -1));
        }
    }
}
