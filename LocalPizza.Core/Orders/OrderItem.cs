﻿using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public bool IsPizza { get; set; }
        public PizzaBase Base { get; set; }
        public PizzaCrust Crust { get; set; }
        public int Quantity { get; set; }
        public List<Topping> Toppings { get; set; }
        public Item Item { get; set; }
    }
}
