﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalPizza.Core.Menu;
using LocalPizza.Core.Menu.ViewModels;
using LocalPizza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocalPizza.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly LocalPizzaContext _context;
        private readonly IDataAccess dataAccess;

        public MenuController(LocalPizzaContext context, IDataAccess dataAccess)
        {
            _context = context;
            this.dataAccess = dataAccess;
        }

        // GET: api/menu
        [HttpGet]
        public IEnumerable<ItemViewModel> GetSaleProducts()
        {
            return dataAccess.GetItemViews();
        }
    }
}
