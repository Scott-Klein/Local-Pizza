using LocalPizza.Core.Interfaces;
using LocalPizza.Core.Menu;
using System.Collections.Generic;

namespace LocalPizza.Data
{
    public interface IDataAccess
    {
        IItem InsertItem(IItem item);

        IItem UpdateItem(IItem item);

        Item GetItem(int id);

        bool DeleteItem(int id);

        IEnumerable<Item> GetAllItems();

        IEnumerable<IMenuCategory> GetMenus();
    }
}