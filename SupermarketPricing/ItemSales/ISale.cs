namespace SupermarketPricing.ItemSales
{
    public interface ISale
    {
        public Money AdjustCost(Money initialCost, int quantity);
    }
}
