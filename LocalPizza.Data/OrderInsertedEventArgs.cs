using LocalPizza.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Data
{
    public class OrderInsertedEventArgs : EventArgs
    {
        public OrderInsertedEventArgs(Order order)
        {
            Order = order;
        }

        public Order Order { get; set; }
    }
}
