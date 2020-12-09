using LocalPizza.Core;
using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalPizza.Data
{
    public class DataBaseAccess : IDataAccess
    {
        public List<Item> Items { get; set; }

        private readonly LocalPizzaContext db;

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
            return from i in db.Items
                   orderby i.Name
                   select i;
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
    }
}