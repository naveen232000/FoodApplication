﻿using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppDALLayer.Service;
using FoodAppUILayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodAppUILayer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }
        private readonly IAdminRepository adminRepository;
        private readonly IUserRepository userRepository;

        public AccountController(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            this.adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // GET: Account
        //User
        public ActionResult UserLogin()
        {

            return View();
        }

        //Admin login
        public ActionResult AdminLogin()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(LoginViewModel loginView)
        {
            var isAdmin = Authentication.VerifyAdminCredentials(loginView.UserName, loginView.Password);

            if (isAdmin)
            {
                var admin = adminRepository.GetAdminByUserName(loginView.UserName);
                Session["UserId"] = admin.Id;
                Session["UserName"] = admin.UserName;
                FormsAuthentication.SetAuthCookie(loginView.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If authentication fails, you may want to show an error message.
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(loginView);
            }
        }
        //Admin Reset Password
        public ActionResult AdminResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminResetPassword(ResetPasswordViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                var admin = adminRepository.GetAdminByUserName(model.UserName);

                if (admin == null)
                {
                    ModelState.AddModelError(nameof(model.UserName), "Invalid username. Please enter a valid username.");
                    return View(model);
                }
                else
                {
                    var passwordHash = new PasswordHasher<Admin>();
                    admin.Password = passwordHash.HashPassword(admin, model.Password);
                    adminRepository.Save();
                }
                TempData["SuccessMessage"] = "Password reset successfully. Please log in with your new password.";
                return RedirectToAction("AdminLogin", "Account");
            }
            return View(model);
        }

    }
}