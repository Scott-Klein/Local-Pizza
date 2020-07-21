using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Interfaces
{
    public interface IMenuCategory
    {
        public IEnumerable<IItemGroup> ItemGroups { get; set; }
    }
}
