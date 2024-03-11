using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodAppDbContext _context;

        public UserRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
  
        public User GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName);
        }
        public User GetUserByEmail(string mailId)
        {
            return _context.Users.FirstOrDefault(x => x.Email == mailId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Detach(User entity)
        {
            var context = _context as DbContext;
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            objectContext.Detach(entity);
        }
    }
}
