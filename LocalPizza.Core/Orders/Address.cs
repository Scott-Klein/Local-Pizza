using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocalPizza.Core.Orders
{
    /* Validate address with an API
     * https://geocode.search.hereapi.com/v1/geocode?q=Invalidenstr+117%2C+Berlin&apiKey=njeV3a_SpByHooDYVyHWrPPd5Cn2pxZETDHPeVvluQA
     * 
     */
    public class Address
    {
        public int Id { get; set; }

        [Range(1, 9999)]
        public string Unit { get; set; }
        [Range(1, 9999)]
        public string StreetNumber { get; set; }
        [StringLength(80)]
        public string StreetName { get; set; }

        [RegularExpression(@"^[a-zA-Z]{2,80}$", ErrorMessage = "Suburbs are from 2 to 80 characters, using any upper or lower chase characters.")]
        public string Suburb { get; set; }

        [RegularExpression(@"^[2-8]{1}[0-9]{3}$", ErrorMessage = "POST codes are 4 digits long with a valid range of 2000-8999 in Australia.")]
        public string PostCode { get; set; }

        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}
