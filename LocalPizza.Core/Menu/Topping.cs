using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Menu
{
    public class Topping
    {
        public Topping()
        {
            this.Items = new List<Item>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<Item> Items { get; set; }
    }
}
