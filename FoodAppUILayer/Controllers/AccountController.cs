using CaptchaMvc.HtmlHelpers;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppDALLayer.Service;
using FoodAppUILayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace FoodAppUILayer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }
        private readonly IAdminRepository adminRepository;
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;

        public AccountController(IAdminRepository adminRepository, IUserRepository userRepository, IRestaurantRepository restaurantRepository)
        {
            this.adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // GET: Account
        //User
        public ActionResult UserLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(LoginViewModel loginView)
        {
            // Check if the CAPTCHA is valid.
            if (!this.IsCaptchaValid("Captcha is not valid"))
            {
                ModelState.AddModelError(string.Empty, "Captcha is not valid");
                return View(loginView);
            }
            var isUser = Authentication.VerifyUserCredentials(loginView.UserName, loginView.Password);

            if (isUser)
            {
                var user = userRepository.GetUserByUserName(loginView.UserName);
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
                FormsAuthentication.SetAuthCookie(loginView.UserName, false);
                return RedirectToAction("About", "Home");
            }
            else
            {
                // If authentication fails, you may want to show an error message.
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(loginView);
            }
        }
        [HttpGet]
        public ActionResult UserResetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.GetUserByUserName(model.UserName);

                if (user == null)
                {
                    ModelState.AddModelError(nameof(model.UserName), "Invalid username.");
                   
                    return View(model);
                }
                else
                {
                    var passwordHash = new PasswordHasher<User>();
                    user.Password = passwordHash.HashPassword(user, model.Password);
                    userRepository.Save();
                }
                TempData["SuccessMessage"] = "Password reset successfully. Please log in with your new password.";
                return RedirectToAction("UserLogin", "Account");
            }
            return View(model);
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(User model)
        { // Check if the CAPTCHA is valid.
            if (!this.IsCaptchaValid("Captcha is not valid"))
            {
                ModelState.AddModelError(string.Empty, "Captcha is not valid");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<User>();
                model.Password = passwordHasher.HashPassword(model, model.Password);
                // Create a Product entity from the ViewModel
                User usr = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = model.Password,
                    RoleId = 2
                };

                // Add the product to the database
                userRepository.InsertUser(usr);
                userRepository.Save();

                return RedirectToAction("UserLogin"); // Redirect to the product list page
            }

            return View(model);
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
                return RedirectToAction("Index", "Admin");
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
        //Restaurant
        public ActionResult RestaurantLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestaurantLogin(RestaurantViewModel restview)
        {
            var isRest = Authentication.VerifyRestaurantCredentials(restview.Password, restview.UserName);

            if (isRest)
            {
                var rest = restaurantRepository.GetRestaurantByemail(restview.UserName);
                Session["UserId"] = rest.RestId;
                Session["UserName"] = rest.Email;
                FormsAuthentication.SetAuthCookie(restview.UserName, false);
                return RedirectToAction("AllFoodItems", "Restaurant", new { id = rest.RestId });
            }
            else
            {
                // If authentication fails, you may want to show an error message.
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(restview);
            }
        }
        //logout
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            ViewBag.IsLoggedOut = "true";
            return RedirectToAction("Index", "Home");
        }
    }
}