using SupermarketPricing.ItemSales;

namespace SupermarketPricing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemLookup items = new ItemLookup();

            // prices from https://www.heb.com/
            items.Items.Add(new MarketItem(new Money(1.55), "Fresh Large Mango"));
            items.Items.Add(new MarketItem(new Money(1.85), "HEB Big Bread", new PercentOffSale(.75)));   // Not from HEB, but an discontinued HEB item that I am still bitter about
            items.Items.Add(new MarketItem(new Money(4.99), "Beyond Meat Beyond Burger Plant-Based Patties, 2 pk", new ByXGetY(2, 1)));

            // maybe add the HEB style combo-item sales

            Console.WriteLine($"1 'Fresh Large Mango' cost: {items.GetPrice("Fresh Large Mango", 1)}");
            Console.WriteLine($"2 'half-off HEB Big Bread' cost: {items.GetPrice("HEB Big Bread", 2)}");
            Console.WriteLine($"3 'Beyond Meat Beyond Burger Plant-Based Patties, 2 pk' cost: {items.GetPrice("Beyond Meat Beyond Burger Plant-Based Patties, 2 pk", 3)}");
        }
    }
}
