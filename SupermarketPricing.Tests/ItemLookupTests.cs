using SupermarketPricing.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupermarketPricing.Tests
{
    public class ItemLookupTests
    {
        [Fact]
        public void ItemLookupShouldThrowWhenNameIsNull()
        {
            // Arrange
            var itemLookup = new ItemLookup();
            var marketItem = new MarketItem(new Money(10.49), "Mahatma Basmati Rice");
            itemLookup.Items.Add(marketItem);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(() => itemLookup.GetPrice(null, 1));
        }

        [Fact]
        public void ItemLookupShouldThrowWhenNameIsEmpty()
        {
            // Arrange
            var itemLookup = new ItemLookup();
            var marketItem = new MarketItem(new Money(10.49), "Mahatma Basmati Rice");
            itemLookup.Items.Add(marketItem);

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => itemLookup.GetPrice("", 1));
        }

        [Fact]
        public void ItemLookupShouldThrowWhenItemIsNotFound()
        {
            // Arrange
            var itemLookup = new ItemLookup();
            var marketItem = new MarketItem(new Money(10.49), "Mahatma Basmati Rice");
            itemLookup.Items.Add(marketItem);

            // Assert
            var ex = Assert.Throws<ItemNotInItemLookup>(() => itemLookup.GetPrice("Pasta", 1));
        }

        [Fact]
        public void ItemLookupShouldThrowWhenQuantatyIsNegative()
        {
            // Arrange
            var itemLookup = new ItemLookup();
            var marketItem = new MarketItem(new Money(10.49), "Mahatma Basmati Rice");
            itemLookup.Items.Add(marketItem);

            // Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => itemLookup.GetPrice("Mahatma Basmati Rice", -1));
        }

        [Fact]
        public void ItemLookupShouldReturnExpectedValue()
        {
            // Arrange
            var money = new Money(10.49);
            var itemLookup = new ItemLookup();
            var marketItem = new MarketItem(money, "Mahatma Basmati Rice");
            itemLookup.Items.Add(marketItem);

            // Act
            var result = itemLookup.GetPrice("Mahatma Basmati Rice", 1);

            // Assert
            Assert.Equal(money, result);
        }
    }
}
