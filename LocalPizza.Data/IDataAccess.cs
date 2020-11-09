﻿using LocalPizza.Core.Interfaces;
using LocalPizza.Core.Menu;
using System.Collections.Generic;

namespace LocalPizza.Data
{
    public interface IDataAccess
    {
        Item InsertItem(Item item);

        Item UpdateItem(Item item);

        Item GetItem(int id);

        bool DeleteItem(int id);

        IEnumerable<Item> GetAllItems();

        IEnumerable<IMenuCategory> GetMenus();
    }
}