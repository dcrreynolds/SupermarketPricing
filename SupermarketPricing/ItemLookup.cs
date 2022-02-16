using SupermarketPricing.Exceptions;

namespace SupermarketPricing
{
    public class ItemLookup
    {
        public List<MarketItem> Items { get; set; }

        public ItemLookup()
        {
            Items = new List<MarketItem>();
        }

        public Money GetPrice(string itemName, int quantity)   // support non-int quantities for things that can be subdivided, like by the pound
        {
            if (itemName == null)
            {
                throw new ArgumentNullException(nameof(itemName));
            }

            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentException("itemName cannot be null or empty string.", "itemName");
            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity", "quantity cannot be a negative value.");
            }

            MarketItem item = Items.FirstOrDefault(x => x.Name == itemName);

            if (item == null)
            {
                throw new ItemNotInItemLookup($"Item {itemName} not found in item list.");
            }

            return item.GetPrice(quantity);
        }
    }
}
