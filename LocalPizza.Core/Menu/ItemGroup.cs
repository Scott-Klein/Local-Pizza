using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocalPizza.Core.Menu
{
    public class ItemGroup : IItemGroup
    {
        [Key]
        public int Id { get; set; }

        public string GroupName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public IEnumerable<Item> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}