using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FoodAppDALLayer.Models;
using System.Data;
namespace FoodAppDALLayer.ApplicationDbContext
{
    public class FoodAppDbContext:DbContext
    {
        public FoodAppDbContext():base("name=FoodAppDb")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOptional(o => o.Payment)
                .WithRequired(p => p.Order);
        }
    }
}
