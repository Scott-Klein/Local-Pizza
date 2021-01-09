using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Core.Menu.ViewModels;
using LocalPizza.Core.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LocalPizza.Data.IDataAccess;

namespace LocalPizza.Data
{
    public delegate Task OrderInsertHandler<OrderInsertedEventArgs>(object sender, OrderInsertedEventArgs e);

    public class DataBaseAccess : IDataAccess
    {
        public List<Item> Items { get; set; }

        private readonly LocalPizzaContext db;

        public static event OrderInsertHandler<OrderInsertedEventArgs> OrderInsertEvent;

        public Order InsertOrder(Order order)
        {
            this.db.Orders.Add(order);
            if (this.db.SaveChanges() > 0)
            {
                if(DataBaseAccess.OrderInsertEvent != null)
                {
                    DataBaseAccess.OrderInsertEvent(this, new OrderInsertedEventArgs(order));
                }
            }
            return order;
        }

        public DataBaseAccess(LocalPizzaContext db)
        {
            this.db = db;
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            List<IProduct> products = new List<IProduct>();
            products.AddRange(this.GetAllItems());
            products.AddRange(this.GetAllToppings());
            return products;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return db.Items.Include(x => x.ToppingsList).OrderBy(x => x.Name);
        }
        public IEnumerable<Topping> GetAllToppings()
        {
            return from i in db.Toppings
                   orderby i.Name
                   select i;
        }
        public Item GetItem(int id)
        {
            return db.Items.SingleOrDefault(i => i.Id == id);
        }

        public IProduct GetProduct(int id, ProductRange range)
        {
            if (range == ProductRange.Topping)
            {
                var topping = db.Toppings.SingleOrDefault(i => i.Id == id);
                topping.Range = ProductRange.Topping;
                return topping;
            }
            else
            {
                return GetItem(id);
            }
        }

        public bool Delete(int id, ProductRange range)
        {
            if (range != ProductRange.Topping)
            {
                return this.DeleteItem(id);
            }
            else
            {
                var toDelete = db.Toppings.SingleOrDefault(i => i.Id == id);
                db.Toppings.Remove(toDelete);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteItem(int id)
        {
            var toDelete = db.Items.SingleOrDefault(i => i.Id == id);
            db.Items.Remove(toDelete);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Item InsertItem(Item item)
        {
            db.Add(item);
            db.SaveChanges();
            return item;
        }

        public Item UpdateItem(Item item)
        {
            db.Update(item);
            db.SaveChanges();
            return item;
        }

        public IProduct UpdateProduct(IProduct product)
        {
            db.Update(product);
            db.SaveChanges();
            return product;
        }

        //Links the filename of the uploaded image to the record of the product in the database.
        public IProduct ProductImage(int id, ProductRange range, string filename)
        {
            var product = GetProduct(id, range);
            product.ProductPicture = filename;
            return UpdateProduct(product);
        }

        public IEnumerable<ItemViewModel> GetItemViews()
        {
            var everything = this.GetAllItems().ToList();
            List<ItemViewModel> items = new List<ItemViewModel>();
            for (int i = 0; i < everything.Count; i++)
            {
                items.Add(new ItemViewModel(everything[i]));
            }
            return items;
        }

        public IEnumerable<ToppingViewModel> GetToppingViewModels()
        {
            List<ToppingViewModel> tvm = new List<ToppingViewModel>();
            var toppings = this.GetAllToppings().ToList();
            for (int i = 0; i < toppings.Count(); i++)
            {
                tvm.Add(new ToppingViewModel(toppings[i]));
            }
            return tvm;
        }

        public Topping GetTopping(int id)
        {
            return this.db.Toppings.Find(id);
        }

        public OrderStatus GetOrderStatus(int id)
        {
            var order = this.db.Orders.Find(id);
            return order.Status;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return this.db.Orders.ToList();
        }

        public async Task<Order> IncrementStatus(int id)
        {
            var order = await this.db.Orders.FindAsync(id);
            if (order.Status != OrderStatus.Completed)
            {
                order.Status++;
            }
            //this.db.Orders.Update(order);
            await this.db.SaveChangesAsync();
            return order;
        }

        public int CountOrderItems(int productId)
        {
            //return this.db.OrderItems.Count(o => o.Item.Id == productId);
            var orders = this.db.OrderItems.Where(o => o.Item.Id == productId).ToList();
            int result = 0;
            foreach (var order in orders)
            {
                result += order.Quantity;
            }
            return result;
        }
    }
}