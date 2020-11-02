using LocalPizza.Core.Menu;
using System.Collections.Generic;

namespace LocalPizza.Core.Interfaces
{
    public interface IItemGroup
    {
        public string GroupName { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}