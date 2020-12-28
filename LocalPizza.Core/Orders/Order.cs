using NodaTime;
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
        public LocalTime RequestDelivery { get; set; }
        public List<ItemOrder> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public LocalDateTime Created { get; set; }
        public LocalDateTime DeliveredTime { get; set; }
        public string DeliveryInstructions { get; set; }

        public List<LocalTime> ListTimes()
        {
            var now = new LocalTime(DateTime.Now.Hour, DateTime.Now.Minute);
            LocalTime first = new LocalTime();
            if (now.Minute / 15 == 3)
            {
                first = first.PlusHours(1);
            } else
            {
                first = first.PlusMinutes(15 + (now.Minute / 15));
            }
            //make this a constant somewhere meaningful.
            LocalTime closeTime = new LocalTime(22,30); //Represents the closing time of the store.

            List<LocalTime> times = new List<LocalTime>();
            times.Add(first);
            while (first < closeTime)
            {
                first = first.PlusMinutes(15);
            }

            return times;
        }
    }
}
