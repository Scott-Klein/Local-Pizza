using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Menu.ViewModels
{
    public class ToppingViewModel
    {
        public ToppingViewModel(Topping topping)
        {
            this.Id = topping.Id;
            this.Name = topping.Name;
            this.Price = topping.Price.ToString();
            this.ProductPicture = topping.ProductPicture;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string ProductPicture { get; set; }
    }
}
