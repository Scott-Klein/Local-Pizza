using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocalPizza.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        private readonly IDataAccess dataAccess;
        private readonly IHtmlHelper htmlHelper;

        public Item Item { get; set; }
        public IEnumerable<SelectListItem> Range { get; set; }

        public AddProductModel(IDataAccess injectedDataService, IHtmlHelper htmlHelper)
        {
            this.dataAccess = injectedDataService;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {
            this.Item = new Item();
            this.Range = htmlHelper.GetEnumSelectList<ProductRange>();
        }
    }
}
