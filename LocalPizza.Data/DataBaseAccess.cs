using LocalPizza.Core.Menu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalPizza.Data
{
    public class DataBaseAccess : IDataAccess
    {
        public List<Item> Items { get; set; }
        public List<ItemGroup> ItemGroups { get; set; }
        public List<MenuCategory> MenuCategories { get; set; }

        private readonly LocalPizzaContext db;

        public DataBaseAccess(LocalPizzaContext db)
        {
            this.db = db;
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

        public IEnumerable<Item> GetAllItems()
        {
            return from i in db.Items
                   orderby i.Name
                   select i;
        }

        public Item GetItem(int id)
        {
            return db.Items.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<MenuCategory> GetMenus()
        {
            throw new NotImplementedException();
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
    }
}