using LocalPizza.Core.Interfaces;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LocalPizza.Pages
{
    public class MenuModel : PageModel
    {
        private readonly DataAccess dataAccess;

        public MenuModel(DataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public IEnumerable<IMenuCategory> Menus { get; set; }

        public void OnGet()
        {
            //request from dataAccess to get data.
            Menus = dataAccess.GetMenus();
        }
    }
}