using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Core.Menu.ViewModels;
using LocalPizza.Core.Orders;
using System.Collections.Generic;

namespace LocalPizza.Data
{
    public interface IDataAccess
    {
        Item InsertItem(Item item);

        Item UpdateItem(Item item);
        IProduct UpdateProduct(IProduct product);
        public Item GetItem(int id);
        public IProduct GetProduct(int id, ProductRange range);
        bool DeleteItem(int id);
        Order InsertOrder(Order order);
        IEnumerable<Item> GetAllItems();
        IEnumerable<ToppingViewModel> GetToppingViewModels();
        public Topping GetTopping(int id);
        IEnumerable<IProduct> GetAllProducts();
        IEnumerable<ItemViewModel> GetItemViews();
        IProduct ProductImage(int id, ProductRange range, string filename);
        bool Delete(int id, ProductRange range);
    }
}