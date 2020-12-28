using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core
{
    public class ItemOrder : Item
    {
        public int Quantity { get; set; }
        public ItemOrder(Item item, int qty)
        {
            this.Range = item.Range;
            this.Name = item.Name;
            this.Price = item.Price + item.CalculateToppingsPrice();
            this.ProductPicture = item.ProductPicture;
            this.Description = item.Description;
            this.Quantity = qty;
        }
    }
}
