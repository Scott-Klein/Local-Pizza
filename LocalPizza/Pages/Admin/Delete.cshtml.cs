using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocalPizza.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IDataAccess dataAccess;

        public IProduct item { get; set; }

        public DeleteModel(IDataAccess data)
        {
            this.dataAccess = data;
        }

        public IActionResult OnGet(int id, ProductRange range)
        {

            item = dataAccess.GetProduct(id, range);
            if (item == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int id, ProductRange range)
        {
            if (dataAccess.Delete(id, range))
            {
                return RedirectToPage("./ProductList");
            }
            else
            {
                return RedirectToPage("./NotFound");
            }
        }
    }
}
