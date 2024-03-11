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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
         .HasRequired(o => o.Order)
         .WithMany(o => o.OrderItems) 
         .HasForeignKey(o => o.OrderId)
         .WillCascadeOnDelete(true); 

            base.OnModelCreating(modelBuilder);


        }
    }
}
