using LocalPizza.Core.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NodaTime;
using LocalPizza.Data;
using LocalPizza.Data.Extensions;

namespace LocalPizza.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IDataAccess dataAccess;

        public OrderController(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        [HttpPost]
        public IActionResult CreateOrder(InMemoryOrder order)
        {

            order.Created = LocalDateTime.FromDateTime(DateTime.Now);
            var actionresult = CreatedAtAction("CreateOrder", dataAccess.InsertOrder(order.DatabaseOrderFactory(this.dataAccess)));

            return actionresult;
        }
    }
}
