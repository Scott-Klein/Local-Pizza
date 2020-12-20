using LocalPizza.Core.Menu.ViewModels;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalPizza.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingViewController : ControllerBase
    {
        private readonly IDataAccess dataAccess;

        public ToppingViewController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        //api/toppingview
        [HttpGet]
        public IEnumerable<ToppingViewModel> GetToppingViewModels()
        {
            return this.dataAccess.GetToppingViewModels();
        }
    }
}
