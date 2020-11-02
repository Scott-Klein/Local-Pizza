using LocalPizza.Core.Menu;
using System.Collections.Generic;

namespace LocalPizza.Core.Interfaces
{
    public interface IMenuCategory
    {
        public string Name { get; set; }
        public IEnumerable<ItemGroup> ItemGroups { get; set; }
    }
}