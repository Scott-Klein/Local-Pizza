using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Menu
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
