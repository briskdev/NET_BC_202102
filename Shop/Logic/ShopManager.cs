using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop
{
    // Class for the logic
    class ShopManager
    {
        private Basket Basket { get; set; }
        private Storage Storage { get; set; }

        // In the constructor new basket and new storage are created
        public ShopManager()
        {
            Basket = new Basket();
            Storage = new Storage();
        }

        // method returns all the items inside Storage, sorted by the name 
        public List<Item> GetAvailableItems()
        {
            return Storage.Items.OrderBy(Item => Item.Name).ToList();
        }

        // method check if item by this name exists in the storage. 
        // If not - returns null, otherwise adds item to the basket and returns it as result.
        public Item AddToBasket(string name)
        {
            Item item = Storage.Items.Find(i => i.Name.ToLower() == name.ToLower());

            if(item != null)
            {
                Basket.Items.Add(item);
            }

            return item;
        }

        // Returns total price of all items in the basket
        public decimal CheckOut()
        {
            return Basket.CalculateTotalPrice();
        }

        // Returns all items in the basket, sorted by the price 
        public List<Item> Pay()
        {
            return Basket.Items.OrderBy(i => i.Price).ToList();
        }
    }
}
