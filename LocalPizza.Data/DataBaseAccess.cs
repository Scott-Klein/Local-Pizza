using LocalPizza.Core.Interfaces;
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

        //private readonly LocalPizzaContext db;

        public DataBaseAccess(LocalPizzaContext db)
        {
            Items = new List<Item>();
            //this.db = db;
        }

        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return from i in Items
                   orderby i.Name
                   select i;
        }

        public Item GetItem(int id)
        {
            return Items.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<IMenuCategory> GetMenus()
        {
            throw new NotImplementedException();
        }

        public Item InsertItem(Item item)
        {
            //db.Add(item);
            //db.SaveChanges();
            return item;
        }

        public IItem UpdateItem(IItem item)
        {
            throw new NotImplementedException();
        }
    }
}