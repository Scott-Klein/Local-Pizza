using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalPizza.Core.Interfaces;
namespace LocalPizza.Pages
{
    public class MenuModel : PageModel
    {
        public void OnGet()
        {
            //request from the entity framework to get the data.
        }

        public IEnumerable<IMenuCategory> Menus { get; set; }
    }
}