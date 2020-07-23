using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalPizza.Core.Interfaces;
using Microsoft.Data.SqlClient.Server;
using LocalPizza.Data;

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