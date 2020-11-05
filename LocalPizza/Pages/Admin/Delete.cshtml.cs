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
    public class DeleteModel : PageModel
    {
        private readonly IDataAccess dataAccess;

        public Item item { get; set; }

        public DeleteModel(IDataAccess data)
        {
            this.dataAccess = data;
        }

        public IActionResult OnGet(int Id)
        {
            item = dataAccess.GetItem(Id);
            if (item == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(int id)
        {
            if (dataAccess.DeleteItem(id))
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
