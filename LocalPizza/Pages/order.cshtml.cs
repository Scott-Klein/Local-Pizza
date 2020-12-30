using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocalPizza.Core.Orders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using NodaTime;

namespace LocalPizza.Pages
{   
    [BindProperties]
    public class OrderModel : PageModel
    {
        private readonly IHtmlHelper htmlHelper;

        public Order CurrentOrder { get; set; }

        public string TestMessage { get; set; }
        public List<SelectListItem> TimesSelect { get; set; }
        public OrderModel(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
            this.TimesSelect = new List<SelectListItem>();

        }

        public void OnGet()
        {
            TimesSelect = new List<SelectListItem>();
            this.CurrentOrder = new Order();
            PopulateSelectListItems();
        }
        public void OnPost()
        {
            this.CurrentOrder.Created = LocalDateTime.FromDateTime(DateTime.Now);
        }
        private void PopulateSelectListItems()
        {
            var times = this.CurrentOrder.ListTimes();
            var culture = new CultureInfo("en-US");
            foreach (var time in times)
            {
                this.TimesSelect.Add(new SelectListItem(time.ToString("H:mm", culture), time.ToString()));
            }
            this.TimesSelect[0].Text = "Now";
        }
    }
}
