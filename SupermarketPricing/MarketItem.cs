using SupermarketPricing.ItemSales;

namespace SupermarketPricing
{
    public class MarketItem
    {
        public Money SingleUnitCost
        {
            get => _singleUnitCost;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Item cannot have a negative cost.");
                }

                _singleUnitCost = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty string", "Name");
                }

                _name = value;
            }
        }
        public ISale Sale { get; set; }

        private string _name;
        private Money _singleUnitCost;

        public MarketItem(Money singleUnitCost, string name)
        {
            SingleUnitCost = singleUnitCost;
            Name = name;
            Sale = new NoSale();
        }

        public MarketItem(Money singleUnitCost, string name, ISale sale)
        {
            // add null check everywhere

            SingleUnitCost = singleUnitCost;
            Name = name;
            Sale = sale;
        }

        public Money GetPrice(int quantity)
        {
            return Sale.AdjustCost(SingleUnitCost, quantity);
        }
    }
}
