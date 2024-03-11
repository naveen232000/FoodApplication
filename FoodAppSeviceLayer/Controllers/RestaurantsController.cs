using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Models;

namespace FoodAppSeviceLayer.Controllers
{
    public class RestaurantsController : ApiController
    {
        private readonly FoodAppDbContext _context;

        public RestaurantsController()
        {
            _context = new FoodAppDbContext();
        }

    
        public IEnumerable<Restaurant> GetRestaurant()
        {
            return _context.Restaurants.ToList();
        }

        public IHttpActionResult GetRestaurant(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }


        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != restaurant.RestId)
                return BadRequest();

            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(restaurant);
        }

    
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = restaurant.RestId }, restaurant);
        }


        public IHttpActionResult DeleteRestaurant(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if (restaurant == null)
                return NotFound();

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
            return Ok(restaurant);
        }
    }
}