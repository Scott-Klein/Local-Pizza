using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace LocalPizza.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IDataAccess dataAccess;

        public MenuModel(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public List<Item> SaleItems { get; set; }

        public void OnGet()
        {
            //request from dataAccess to get data.
            SaleItems = this.dataAccess.GetAllItems().ToList();
        }

        public List<Item> GetRange(ProductRange range)
        {
            return SaleItems.Where(i => i.Range == range).ToList();
        }
    }
}