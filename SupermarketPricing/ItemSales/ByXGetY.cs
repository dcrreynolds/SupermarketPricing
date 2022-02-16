namespace SupermarketPricing.ItemSales
{
    public class ByXGetY : ISale
    {
        public int BuyQuantity
        {
            get => _buyQuantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "BuyQuantity must be above 0.");
                }

                _buyQuantity = value;
            }
        }
        public int GetQuantity
        {
            get => _getQuantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "GetQuantity must be above 0.");
                }

                _getQuantity = value;
            }
        }

        private int _buyQuantity;
        private int _getQuantity;

        public ByXGetY(int buyQuantity, int getQuantity)
        {
            BuyQuantity = buyQuantity;
            GetQuantity = getQuantity;
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

            int purchaseGroupSize = BuyQuantity + GetQuantity;

            int numberGroupsPurchased = quantity / purchaseGroupSize;

            return initialCost * (quantity - numberGroupsPurchased);
        }
    }
}
