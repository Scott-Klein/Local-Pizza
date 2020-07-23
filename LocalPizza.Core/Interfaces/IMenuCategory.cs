using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Interfaces
{
    public interface IMenuCategory
    {
        public string Name { get; set; }
        public IEnumerable<IItemGroup> ItemGroups { get; set; }
    }
}
