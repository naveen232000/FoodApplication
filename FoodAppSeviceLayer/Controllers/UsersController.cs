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

        // GET api/users
        public IEnumerable<User> GetUser()
        {
            return _context.Users.ToList();
        }

        // GET api/users/{id}
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // PUT api/users/{id}
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

        // POST api/users
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE api/users/{id}
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
