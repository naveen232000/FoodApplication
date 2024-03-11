using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodAppDbContext _context;

        public RestaurantRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurantById(int id)
        {

            return _context.Restaurants.Find(id);
        }

        public  void InsertRestaurant(Restaurant restaurant)
        {
             _context.Restaurants.Add(restaurant);
        }

        public void DeleteRestaurant(int id)
        {
            Restaurant restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
        }
       
        public Restaurant GetRestaurantByemail(string email)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Email == email);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Detach(Restaurant entity)
        {
            var context = _context as DbContext; 
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            objectContext.Detach(entity);
        }
    }
}
