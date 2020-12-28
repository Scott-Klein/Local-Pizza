using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalPizza.Core.Orders;

namespace LocalPizza.Pages
{
    public class orderModel : PageModel
    {
        public Order CurrentOrder { get; set; }
        public void OnGet()
        {
        }
    }
}
