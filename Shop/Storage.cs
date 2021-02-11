using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    // Class for available items (catalog)
    class Storage
    {
        public List<Item> Items { get; set; }

        // In the constructor list is filled with predefined items
        public Storage()
        {
            Items = new List<Item>();
            Items.Add(new Item("PC", 900));
            Items.Add(new Item("Pants", 50));
            Items.Add(new Item("Car", 10000));
            Items.Add(new Item("Mobile", 200));
            Items.Add(new Item("TV", 550));
            Items.Add(new Item("Glasses", 100));
            Items.Add(new Item("Gloves", 20));
            Items.Add(new Item("Hat", 10));
        }
    }
}
