using LocalPizza.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalPizza.Hubs
{
    public class PizzaDbFactory
    {
        
        public static LocalPizzaContext GetPizzaContext()
        {
            var optionbuilder = new DbContextOptionsBuilder<LocalPizzaContext>();
            optionbuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=pizza-db;Integrated Security=True;");
            return new LocalPizzaContext(optionbuilder.Options);
        }

    }
}
