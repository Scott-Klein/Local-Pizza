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
    public class EditProductModel : PageModel
    {
        public Item Item { get; set; }

        private readonly IDataAccess data;

        public EditProductModel(IDataAccess injectedData)
        {
            this.data = injectedData;
        }

        public IActionResult OnGet(int id)
        {
            this.Item = this.data.GetItem(id);
            if (this.Item == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
