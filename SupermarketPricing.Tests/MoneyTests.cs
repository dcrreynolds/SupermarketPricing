using Xunit;

namespace SupermarketPricing.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void MoneyShouldRoundUpFractionalCentsWhenApprpriate()
        {
            // Arrange
            var money = new Money(1.328);

            // Assert
            Assert.Equal(1.33, money.Amount);
        }

        [Fact]
        public void MoneyShouldRoundDownFractionalCentsWhenApprpriate()
        {
            // Arrange
            var money = new Money(1.322);

            // Assert
            Assert.Equal(1.32, money.Amount);
        }

        [Fact]
        public void MoneyShouldRoundWhenMultiplyingInt()
        {
            // Arrange
            var money = new Money(1.322);

            // Act
            var moneyMult = money * 3;

            // Assert
            Assert.Equal(3.96, moneyMult.Amount);
        }

        [Fact]
        public void MoneyShouldSoubleRoundWhenMultiplyingDouble()
        {
            // Arrange
            var money = new Money(1.322);

            // Act
            var moneyMult = money * 3.15;

            // Assert
            Assert.Equal(4.16, moneyMult.Amount);
        }

        [Fact]
        public void MoneyShouldReturnStringWith2Decimals()
        {
            // Arrange
            var money = new Money(1.322);

            // Assert
            Assert.Equal("1.32", money.ToString());
        }
    }
}
