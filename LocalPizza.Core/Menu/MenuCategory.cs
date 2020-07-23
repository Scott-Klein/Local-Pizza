using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Menu
{
    class MenuCategory : IMenuCategory
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IItemGroup> ItemGroups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
