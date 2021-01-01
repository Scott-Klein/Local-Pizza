using LocalPizza.Core.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NodaTime;

namespace LocalPizza.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOrder(InMemoryOrder order)
        {
            order.Created = LocalDateTime.FromDateTime(DateTime.Now);

            //Lets store this in the database.
            return NoContent();
        }
    }
}
