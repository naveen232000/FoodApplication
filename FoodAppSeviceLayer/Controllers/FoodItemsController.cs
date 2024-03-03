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
        private FoodAppDbContext db = new FoodAppDbContext();

        // GET: api/FoodItems
        public IQueryable<FoodItem> GetFoodItems()
        {
            return db.FoodItems;
        }

        // GET: api/FoodItems/5
        [ResponseType(typeof(FoodItem))]
        public IHttpActionResult GetFoodItem(int id)
        {
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return Ok(foodItem);
        }

        // PUT: api/FoodItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFoodItem(int id, FoodItem foodItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodItem.FoodId)
            {
                return BadRequest();
            }

            db.Entry(foodItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FoodItems
        [ResponseType(typeof(FoodItem))]
        public IHttpActionResult PostFoodItem(FoodItem foodItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FoodItems.Add(foodItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = foodItem.FoodId }, foodItem);
        }

        // DELETE: api/FoodItems/5
        [ResponseType(typeof(FoodItem))]
        public IHttpActionResult DeleteFoodItem(int id)
        {
            FoodItem foodItem = db.FoodItems.Find(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            db.FoodItems.Remove(foodItem);
            db.SaveChanges();

            return Ok(foodItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodItemExists(int id)
        {
            return db.FoodItems.Count(e => e.FoodId == id) > 0;
        }
    }
}