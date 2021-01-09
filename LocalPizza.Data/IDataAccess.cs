using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Core.Menu.ViewModels;
using LocalPizza.Core.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalPizza.Data
{
    public interface IDataAccess
    {
        int CountOrderItems(int productId);
        Item InsertItem(Item item);
        Task<Order> IncrementStatus(int id);
        Item UpdateItem(Item item);
        IProduct UpdateProduct(IProduct product);
        public Item GetItem(int id);
        public IProduct GetProduct(int id, ProductRange range);
        bool DeleteItem(int id);
        Order InsertOrder(Order order);
        IEnumerable<Item> GetAllItems();
        OrderStatus GetOrderStatus(int id);
        IEnumerable<ToppingViewModel> GetToppingViewModels();
        public Topping GetTopping(int id);
        IEnumerable<IProduct> GetAllProducts();
        IEnumerable<Order> GetAllOrders();
        IEnumerable<ItemViewModel> GetItemViews();
        IProduct ProductImage(int id, ProductRange range, string filename);
        bool Delete(int id, ProductRange range);
    }
}