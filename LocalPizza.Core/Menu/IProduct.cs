using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Menu
{
    public interface IProduct
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public ProductRange Range { get; set; }
        public string ProductPicture { get; set; }
    }
}
