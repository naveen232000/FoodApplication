using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodAppSeviceLayer.Controllers
{
    public class UsersController : ApiController
    {
        private readonly FoodAppDbContext _context;

        public UsersController()
        {
            _context = new FoodAppDbContext(); 
        }

      
        public IEnumerable<User> GetUser()
        {
            return _context.Users.ToList();
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != user.UserId)
                return BadRequest();

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(user);
        }

        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }


        public IHttpActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}
