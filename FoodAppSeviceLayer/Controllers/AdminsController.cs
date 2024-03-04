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
    public class AdminsController : ApiController
    {
        private readonly FoodAppDbContext _context;


        public AdminsController()
        {
            _context = new FoodAppDbContext(); // Initialize DbContext
        }

        // GET api/admins
        public IEnumerable<Admin> GetAdmin()
        {
            return _context.Admins.ToList();
        }

        // GET api/products/{id}
        public IHttpActionResult GetAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        // PUT api/admins/{id}
        public IHttpActionResult PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != admin.Id)
                return BadRequest();

            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(admin);
        }

        // POST api/admins
        public IHttpActionResult PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Admins.Add(admin);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = admin.Id }, admin);
        }

        // DELETE api/admins/{id}
        public IHttpActionResult DeleteAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null)
                return NotFound();

            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return Ok(admin);
        }
    }
}
