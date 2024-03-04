using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int id);
        void InsertAdmin(Admin admin);
        void DeleteAdmin(int adminId);
        void UpdateAdmin(Admin admin);
        Admin GetAdminByUserName(string userName);
        void Save();
    }
}
