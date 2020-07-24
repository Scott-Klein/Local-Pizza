using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace LocalPizza.Core.Menu
{
    public class MenuCategory : IMenuCategory
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IItemGroup> ItemGroups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}