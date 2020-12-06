using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocalPizza.Pages.Admin
{
    public class EditProductModel : PageModel
    {
        [BindProperty]
        public IProduct Item { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public int MyProperty { get; set; }
        private readonly IDataAccess data;
        private readonly IHtmlHelper helper;
        private readonly IWebHostEnvironment webHost;

        public IEnumerable<SelectListItem> Range { get; set; }

        public EditProductModel(IDataAccess injectedData, IHtmlHelper helper, IWebHostEnvironment webHostEnvironment)
        {
            this.data = injectedData;
            this.helper = helper;
            this.webHost = webHostEnvironment;
        }

        public IActionResult OnGet(int id, ProductRange range)
        {
            this.Range = helper.GetEnumSelectList<ProductRange>();
            this.Item = this.data.GetProduct(id, range);
            if (this.Item == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            /*
             * 
             * How to upload images resource 
             * https://www.c-sharpcorner.com/article/upload-and-display-image-in-asp-net-core-3-1/#:~:text=Upload%20And%20Display%20Image%20In%20ASP.NET%20Core%203.1,wwwroot%20folder%20of%20the%20project.%20More%20items...%20
             *
             */
            
            if (this.Image != null)
            {
                string folder = Path.Combine(webHost.WebRootPath, "images");
                string fileName = Guid.NewGuid().ToString() + "_" + this.Image.FileName;
                string filePath = Path.Combine(folder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    this.Image.CopyTo(fileStream);
                }
                Item.ProductPicture = fileName;
            }

            Item = data.UpdateProduct(Item);

            return RedirectToPage("ProductList");
        }
    }
}
