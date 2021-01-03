using LocalPizza.Core.Orders;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocalPizza.Core.Menu
{
    public class Item : IProduct
    {
        public Item()
        {
            this.ToppingsList = new List<Topping>();
        }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        internal decimal CalculateToppingsPrice()
        {
            decimal result = 0;
            foreach (Topping t in ToppingsList)
            {
                result += t.Price;
            }
            return result;
        }

        public ProductRange Range { get; set; }
        public string ProductPicture { get; set; }

        public List<Topping> ToppingsList { get; set; }

        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; }
    }
}