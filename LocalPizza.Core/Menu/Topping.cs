using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Menu
{
    public class Topping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<Item> Items { get; set; }
    }
}
