using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FoodAppDbContext _context;

        public AdminRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }

        public Admin GetAdminById(int id)
        {
            return _context.Admins.Find(id);
        }

        public void InsertAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
        }

        public void DeleteAdmin(int adminId)
        {
            Admin admin = _context.Admins.Find(adminId);
            _context.Admins.Remove(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
        }
        //ByAdminUserName
        public Admin GetAdminByUserName(string userName)
        {
            return _context.Admins.FirstOrDefault(x => x.UserName == userName);
        }
        public void Save()
        {
                _context.SaveChanges();
        }
    }
}
