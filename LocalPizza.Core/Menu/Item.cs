using System.Collections.Generic;

namespace LocalPizza.Core.Menu
{
    public class Item
    {
        public Item()
        {
            this.ToppingsList = new List<Topping>();
        }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductRange Range { get; set; }
        public string ProductPicture { get; set; }

        public List<Topping> ToppingsList { get; set; }
    }
}