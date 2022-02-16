namespace SupermarketPricing.ItemSales
{
    public class NoSale : ISale
    {
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

            return initialCost * quantity;
        }
    }
}
