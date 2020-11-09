using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Interfaces
{
    public class PizzaTopping
    {
        public int ItemId { get; set; }
        public int ToppingId { get; set; }
        public Item Item { get; set; }
        public Topping Topping { get; set; }
    }
}
