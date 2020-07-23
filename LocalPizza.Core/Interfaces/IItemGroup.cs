using System.Collections.Generic;

namespace LocalPizza.Core.Interfaces
{
    public interface IItemGroup
    {
        public string GroupName { get; set; }
        public IEnumerable<IItem> Items { get; set; }
    }
}