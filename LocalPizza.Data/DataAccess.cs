using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace LocalPizza.Data
{
    public interface DataAccess
    {
        IItem InsertItem(IItem item);

        IItem UpdateItem(IItem item);

        IItem GetItem(int id);

        bool DeleteItem(int id);

        IEnumerable<IItem> GetAllItems();

        IEnumerable<IMenuCategory> GetMenus();
    }

    public class DataBaseAccess : DataAccess
    {
        public bool DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public IItem GetItem(int id)
        {
            throw new NotImplementedException();
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