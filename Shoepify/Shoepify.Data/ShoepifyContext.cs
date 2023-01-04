using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;

namespace Shoepify.Data
{
    public class ShoepifyContext : DbContext
    {
        public ShoepifyContext (DbContextOptions<ShoepifyContext> options)
            : base(options)
        {
        }

        public DbSet<Shoe> Shoes { get; set; } = default!;
    }
}
