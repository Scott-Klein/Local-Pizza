using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    class ShoppingCart
    {
        public List<CartItem> CartItems { get; set; }
        public List<CartPizza> CartPizzas { get; set; }
    }
}
