namespace SupermarketPricing.ItemSales
{
    public class PercentOffSale : ISale
    {
        public double PercentOff
        {
            get => _percentOff;
            set
            {
                if ((value > 0) && (value < 1))
                {
                    _percentOff = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Percent off must be between 0 and 1");
                }
            }
        }

        private double _percentOff;

        public PercentOffSale(double percentOff)
        {
            PercentOff = percentOff;
        }

        public Money AdjustCost(Money initialCost, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity", "quantity cannot be a negative value.");
            }

            if (initialCost == null)
            {
                throw new ArgumentNullException(nameof(initialCost));
            }

            return (initialCost * quantity) * PercentOff;
        }
    }
}
