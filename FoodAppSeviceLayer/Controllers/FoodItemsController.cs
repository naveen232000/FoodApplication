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
    public class FoodItemsController : ApiController
    {
        private readonly FoodAppDbContext _context;

        public FoodItemsController()
        {
            _context = new FoodAppDbContext(); 
        }

        public IEnumerable<FoodItem> GetFoodItem()
        {
            return _context.FoodItems.ToList();
        }

       
        public IHttpActionResult GetFoodItem(int id)
        {
            var foodItem = _context.FoodItems.Find(id);
            if (foodItem == null)
                return NotFound();
            return Ok(foodItem);
        }

    
        public IHttpActionResult PutRestaurant(int id, FoodItem foodItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != foodItem.RestId)
                return BadRequest();

            _context.Entry(foodItem).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(foodItem);
        }

       
        public IHttpActionResult PostRestaurant(FoodItem foodItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.FoodItems.Add(foodItem);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = foodItem.RestId }, foodItem);
        }

       
        public IHttpActionResult DeleteRestaurant(int id)
        {
            var foodItem = _context.FoodItems.Find(id);
            if (foodItem == null)
                return NotFound();

            _context.FoodItems.Remove(foodItem);
            _context.SaveChanges();
            return Ok(foodItem);
        }
    }
}