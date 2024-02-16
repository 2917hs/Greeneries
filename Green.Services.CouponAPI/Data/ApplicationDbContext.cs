using System;
using Green.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Green.Services.CouponAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options)
        {
        }

        public DbSet<Coupon> Coupon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1, Code = "Diwali2023" , Discount = 10M, MinimumAmount = 1000
            });
        }
    }
}

