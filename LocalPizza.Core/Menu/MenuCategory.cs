
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocalPizza.Core.Menu
{
    public class MenuCategory 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<ItemGroup> ItemGroups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}