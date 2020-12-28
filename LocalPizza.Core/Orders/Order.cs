using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address DeliveryAddress { get; set; }
        public DateTime RequestDelivery { get; set; }
        public List<ItemOrder> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime DeliveredTime { get; set; }
        public string DeliveryInstructions { get; set; }
    }
}
