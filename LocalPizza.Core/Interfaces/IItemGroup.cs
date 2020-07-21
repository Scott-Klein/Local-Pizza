using System.Collections.Generic;

namespace LocalPizza.Core.Interfaces
{
    public interface IItemGroup
    {
        public IEnumerable<IItem> Items { get; set; }
    }
}