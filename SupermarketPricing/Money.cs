namespace SupermarketPricing
{
    // Using partial money pattern from https://learning.oreilly.com/library/view/patterns-of-enterprise/0321127420/ch18.xhtml#page_488
    public class Money
    {
        public double Amount
        {
            get => _amount;
            set
            {
                _amount = Math.Round(value, 2, MidpointRounding.AwayFromZero);
            }
        }

        private double _amount;

        public Money(double amount)
        {
            Amount = amount;
        }

        public override string? ToString()
        {
            return String.Format("{0:0.00}", Amount);
        }

        public override bool Equals(object? obj)
        {
            return obj is Money money &&
                   Amount == money.Amount;
        }

        public static Money operator *(Money money, int val)
        {
            return new Money(money.Amount * val);
        }

        public static Money operator *(Money money, double val)
        {
            return new Money(money.Amount * val);
        }
    }
}
