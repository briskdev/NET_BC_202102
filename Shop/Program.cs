using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopManager shop = new ShopManager();

            // items in the storage
            Console.WriteLine("Items available:");
            foreach(var item in shop.GetAvailableItems())
            {
                Console.WriteLine("{0}: EUR {1}", item.Name, item.Price);
            }

            // begin the shopping process
            while(true)
            {
                Console.Write("Enter item's name: ");
                string input = Console.ReadLine();
                if(input == "0")
                {
                    // stop the shopping process
                    break;
                }

                var itemAdded = shop.AddToBasket(input);
                if(itemAdded == null)
                {
                    Console.WriteLine("Item is not available!");
                }
                else
                {
                    Console.WriteLine("Item {0} added!", itemAdded.Name);
                }
            }

            Console.WriteLine("Total price: EUR {0}", shop.CheckOut());
            Console.WriteLine("Your purchase:");
            foreach(var item in shop.Pay())
            {
                Console.WriteLine("{0}: EUR {1}", item.Name, item.Price);
            }
        }
    }
}
