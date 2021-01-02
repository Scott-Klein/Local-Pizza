using LocalPizza.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LocalPizza.Core.Menu
{
    public class Topping :  IProduct
    {
        public Topping()
        {
            this.Items = new List<Item>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductRange Range { get; set; }
        [JsonIgnore]
        public List<Item> Items { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string ProductPicture { get; set; }
    }
}
