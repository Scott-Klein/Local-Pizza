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
        public List<OrderItem> OrderItems { get; set; }
        public string Created { get; set; }
        public Address DeliveryAddress { get; set; }
        public string DeliveredTime { get; set; }
        public string RequestDeliveryTime { get; set; }
        public string DeliveryInstructions { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public OrderStatus Status { get; set; }
    }
}

