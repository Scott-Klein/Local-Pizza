using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    public class Address
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public List<Order> Orders { get; set; }
    }
}
