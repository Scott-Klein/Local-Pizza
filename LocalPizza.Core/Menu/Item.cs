using LocalPizza.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPizza.Core.Menu
{
    class Item : IItem
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ProductName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MenuType MenuType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IMGuri { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
