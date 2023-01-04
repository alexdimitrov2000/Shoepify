using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;

namespace Shoepify.Data
{
    public class ShoepifyContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ShoepifyContext (DbContextOptions<ShoepifyContext> options)
            : base(options)
        {
        }

        public DbSet<Shoe> Shoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
