using LocalPizza.Core.Menu;
using LocalPizza.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Data.Extensions
{
    public static class DataExtensions
    {
        public static OrderItem ConvertToOrderItem(this CartItem ci, IDataAccess data)
        {
            var result = new OrderItem();
            result.IsPizza = false;
            result.Quantity = ci.Qty;
            result.Item = data.GetItem(ci.Id);
            return result;
        }

        public static OrderItem ConvertToOrderItem(this CartPizza cartPizza, IDataAccess data)
        {
            var result = new OrderItem();
            result.IsPizza = true;
            result.Quantity = 1;
            result.Base = cartPizza.Base;
            result.Crust = cartPizza.Crust;
            result.Toppings = cartPizza.GetToppingsFromDB(data);
            return result;
        }

        public static List<Topping> GetToppingsFromDB(this CartPizza cartPizza, IDataAccess data)
        {
            var result = new List<Topping>();
            foreach (var toppingId in cartPizza.Toppings)
            {
                result.Add(data.GetTopping(toppingId));
            }
            return result;
        }

        public static List<OrderItem> ConvertToOrderItems(this InMemoryOrder imo, IDataAccess data)
        {
            var result = new List<OrderItem>();
            
            foreach (var item in imo.OrderItems.CartItems)
            {
                var dbItem = data.GetItem(item.Id); //Get the item data from the database.
                var orderItem = item.ConvertToOrderItem(data); //create the order item.
                orderItem.Item = dbItem; //connect the item data to the order item.
                result.Add(orderItem);
            }

            foreach (var pizza in imo.OrderItems.CartPizzas)
            {
                //Grab the pizza from the db and stick it to the order item so that EF core knows 
                //about the relationship.
                var dbItem = data.GetItem(pizza.ItemId);
                var orderItem = pizza.ConvertToOrderItem(data);
                orderItem.Item = dbItem;
                result.Add(orderItem);
            }

            return result;
        }

        public static Order DatabaseOrderFactory(this InMemoryOrder imo, IDataAccess data)
        {
            var order = new Order();
            order.Created = imo.Created.ToString();
            order.Name = imo.Name;
            order.Phone = imo.PhoneNumber;
            order.Status = imo.Status;
            order.DeliveryAddress = imo.DeliveryAddress;
            order.RequestDeliveryTime = imo.RequestDelivery;
            order.DeliveryInstructions = imo.DeliveryInstructions;
            order.OrderItems = imo.ConvertToOrderItems(data);

            //tell each order item about the order for EF to know about the relationship.
            foreach (var o in order.OrderItems)
            {
                o.Order = order; 
            }
            return order;
        }
    }
}
