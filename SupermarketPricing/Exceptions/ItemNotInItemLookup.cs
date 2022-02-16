namespace SupermarketPricing.Exceptions
{
    public class ItemNotInItemLookup : Exception
    {
        public ItemNotInItemLookup(string message) : base(message)
        { }
    }
}
