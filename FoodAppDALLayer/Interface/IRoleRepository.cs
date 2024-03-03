using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void InsertRole(Role role);
        void DeleteRole(int roleId);
        void UpdateRole(Role role);
        void Save();
    }
}
