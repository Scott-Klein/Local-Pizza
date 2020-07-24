using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Menu
{
    public class ItemGroup : IItemGroup
    {
        public string GroupName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IItem> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
