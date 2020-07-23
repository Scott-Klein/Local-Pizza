using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocalPizza.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LocalPizza.Data
{
    public class LocalPizzaContext : IdentityDbContext
    {
        public LocalPizzaContext(DbContextOptions options) : base(options)
        {

        }

    }
}
