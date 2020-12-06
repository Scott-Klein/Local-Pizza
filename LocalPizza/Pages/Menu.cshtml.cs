using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LocalPizza.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IDataAccess dataAccess;

        public MenuModel(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public void OnGet()
        {
            //request from dataAccess to get data.
        }
    }
}