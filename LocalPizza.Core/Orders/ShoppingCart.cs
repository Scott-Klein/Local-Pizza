using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    public class ShoppingCart
    {

        public CartItem[] CartItems { get; set; }
        public CartPizza[] CartPizzas { get; set; }
    }

}
