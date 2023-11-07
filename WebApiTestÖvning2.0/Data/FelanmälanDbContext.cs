using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTestÖvning2._0.Model;

namespace WebApiTestÖvning2._0.Data
{
    public class FelanmälanDbContext : DbContext
    {
        public FelanmälanDbContext (DbContextOptions<FelanmälanDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiTestÖvning2._0.Model.Felanmälan> Felanmälan { get; set; } = default!;
    }
}
