using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    public class CartPizza
    {
        public int ItemId { get; set; }
        public PizzaBase Base { get; set; }
        public PizzaCrust Crust { get; set; }
        public string Name { get; set; }
        public int[] Toppings { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
    }
}
