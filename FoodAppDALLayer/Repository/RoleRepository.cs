using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FoodAppDbContext _context;

        public RoleRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.Find(id);
        }

        public void InsertRole(Role role)
        {
            _context.Roles.Add(role);
        }

        public void DeleteRole(int roleId)
        {
            Role role = _context.Roles.Find(roleId);
            _context.Roles.Remove(role);
        }

        public void UpdateRole(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
