using LocalPizza.Core;
using LocalPizza.Core.Menu;
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

        IEnumerable<Item> GetAllItems();

        IEnumerable<IProduct> GetAllProducts();

    }
}