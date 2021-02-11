using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    // Class for the logic
    class ShopManager
    {
        public Basket Basket { get; set; }
        public Storage Storage { get; set; }

        // In the constructor new basket and new storage are created
        public ShopManager()
        {
            Basket = new Basket();
            Storage = new Storage();
        }

        // method returns all the items inside Storage, sorted by the name 
        public List<Item> GetAvailableItems()
        {

        }

        // method check if item by this name exists in the storage. 
        // If not - returns null, otherwise adds item to the basket and returns it as result.
        public Item AddToBasket(string name)
        {

        }

        // Returns total price of all items in the basket
        public decimal CheckOut()
        {

        }

        // Returns all items in the basket, sorted by the price 
        public List<Item> Pay()
        {

        }
    }
}
