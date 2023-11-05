using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TylerTech.Models;

namespace TylerTechApp.Data
{
    public class TylerTechAppContext : DbContext
    {
        public TylerTechAppContext (DbContextOptions<TylerTechAppContext> options)
            : base(options)
        {
        }

        public DbSet<TylerTech.Models.Employee> Employee { get; set; } = default!;
    }
}
