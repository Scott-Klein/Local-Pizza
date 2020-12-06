using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalPizza.Pages.Admin
{
    public class ProductListModel : PageModel
    {
        public List<IProduct> Products;
        private readonly IDataAccess data;

        public ProductListModel(IDataAccess data)
        {
            this.data = data;
        }
        public void OnGet()
        {
            Products = data.GetAllProducts().ToList();
        }
    }
}
