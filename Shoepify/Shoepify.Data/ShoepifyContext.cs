using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoepify.Domain;

namespace Shoepify.Data
{
    public class ShoepifyContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ShoepifyContext(DbContextOptions<ShoepifyContext> options)
            : base(options)
        {
        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<ShoeColor> ShoeColors { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<ShoeSize> ShoeSizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Shoe>()
                .HasKey(s => s.Id);

            builder.Entity<Category>()
                .HasKey(c => c.Id);

            builder.Entity<Color>()
                .HasKey(c => c.Id);

            builder.Entity<Size>()
                .HasKey(s => s.Id);

            builder.Entity<Shoe>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Shoes)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ShoeColor>()
                .HasKey(sc => new { sc.ShoeId, sc.ColorId });

            builder.Entity<ShoeColor>()
                .HasOne(sc => sc.Shoe)
                .WithMany(s => s.Colors)
                .HasForeignKey(sc => sc.ShoeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ShoeColor>()
                .HasOne(sc => sc.Color)
                .WithMany(c => c.Shoes)
                .HasForeignKey(sc => sc.ColorId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ShoeSize>()
                .HasKey(ss => new { ss.ShoeId, ss.SizeId });

            builder.Entity<ShoeSize>()
                .HasOne(ss => ss.Shoe)
                .WithMany(s => s.Sizes)
                .HasForeignKey(ss => ss.ShoeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ShoeSize>()
                .HasOne(ss => ss.Size)
                .WithMany(s => s.Shoes)
                .HasForeignKey(ss => ss.SizeId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
