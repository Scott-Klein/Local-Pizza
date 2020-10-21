using System.Collections.Generic;

namespace LocalPizza.Core.Interfaces
{
    public interface IMenuCategory
    {
        public string Name { get; set; }
        public IEnumerable<IItemGroup> ItemGroups { get; set; }
    }
}