using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void InsertUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
        User GetUserByUserName(string userName);
        User GetUserByEmail(string mailId);
        void Save();
        void Detach(User rest);
    }
}
