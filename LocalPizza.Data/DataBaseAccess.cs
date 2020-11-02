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


        public DataBaseAccess()
        {
            Items = new List<Item>();
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

        public IItem InsertItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public IItem UpdateItem(IItem item)
        {
            throw new NotImplementedException();
        }
    }
}