using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Service
{
    public class Authentication
    {
        private static readonly FoodAppDbContext context = new FoodAppDbContext();


        public static bool VerifyAdminCredentials(string username, string password)
        {
            
            var admin = context.Admins.FirstOrDefault(a => a.UserName == username);

            if (admin != null)
            {
                var passwordHasher = new PasswordHasher<Admin>();
                var result = passwordHasher.VerifyHashedPassword(admin, admin.Password, password);

                if (result == PasswordVerificationResult.Success)
                {
                    return true; 
                }
            }

            return false; 
        }
        public static bool VerifyUserCredentials(string username, string password)
        {
           
            var user = context.Users.FirstOrDefault(a => a.UserName == username);

            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

                if (result == PasswordVerificationResult.Success)
                {
                    return true; 
                }
            }

            return false; 
        }

        public static bool VerifyRestaurantCredentials(int id, string Email)
        {
           
            var rest = context.Restaurants.FirstOrDefault(a => a.RestId == id && a.Email==Email);

            if (rest != null)
            {
                
                    return true; 
            
            }

            return false; 
        }
    }
}
