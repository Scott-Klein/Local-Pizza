using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Menu.ViewModels
{
    /*
     * This is intended to be used for viewing items and their associated toppings if they have any.
     * The constraint that only pizza may have toppings is not enforced in this version of the viewmodel.
     * It is assumed that the state of the database is correct and consistent. This model is oonly responsible
     * for viewing.
     */
    public class ItemViewModel
    {
        public ItemViewModel(Item item)
        {
            this.Id = item.Id;
            this.Price = item.Price.ToString();
            this.Name = item.Name;
            this.Description = item.Description;
            this.Range = item.Range;
            this.ProductPicture = item.ProductPicture;
            this.VMToppings(item.ToppingsList);
            
        }

        public int Id { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductRange Range { get; set; }
        public string ProductPicture { get; set; }

        public List<ToppingViewModel> Toppings { get; set; }


        private void VMToppings(List<Topping> toppings)
        {
            this.Toppings = new List<ToppingViewModel>();
            for (int i = 0; i < toppings.Count; i++)
            {
                ToppingViewModel tvm = new ToppingViewModel(toppings[i]);
                Toppings.Add(tvm);
            }
        }
    }
}
