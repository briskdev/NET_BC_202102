using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop
{
    // Class for users's basket    
    class Basket
    {
        public List<Item> Items { get; set; }

        // In the constructor empty list is created
        public Basket()
        {
            Items = new List<Item>();
        }

        public decimal CalculateTotalPrice()
        {
            /*
            decimal total = 0;
            foreach(var item in Items)
            {
                total += item.Price;
            }

            return total;
            */

            // OR:
            return Items.Sum(i => i.Price);
        }
    }
}
