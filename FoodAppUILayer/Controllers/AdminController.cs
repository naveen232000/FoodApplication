using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppUILayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAppUILayer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
    
        private readonly IRatingRepository ratingRepository;
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IFoodItemRepository foodItemRepository;

        public AdminController(IRatingRepository ratingRepository, IRestaurantRepository restaurantRepository, IUserRepository userRepository, IOrderRepository orderRepository, IFoodItemRepository foodItemRepository)
        {
            this.ratingRepository = ratingRepository ?? throw new ArgumentNullException(nameof(ratingRepository));
            this.restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this.foodItemRepository = foodItemRepository;
        }
        //Admin
        public ActionResult Index()
        {

            var ordersRepo = orderRepository.GetAllOrders();
            int orderCount = ordersRepo.Count();
            var userrepo = userRepository.GetAllUsers();
            int userCount = userrepo.Count();
            var restRepo = restaurantRepository.GetAllRestaurants();
            int restCount = restRepo.Count();
            var foodRepo = foodItemRepository.GetAllFoodItems();
            int foodCount = foodRepo.Count();

            var model = new IndexViewModel
            {
                OrderCount = orderCount,
                UserCount = userCount,
                RestaurantCount = restCount,
                FoodItemCount=foodCount,
            };

            return View(model);
        }

       //Restaurant Crud
        public ActionResult AllRestaurant()
        {
            var restaurants = restaurantRepository.GetAllRestaurants();
            var restaurantsModel = restaurants.Select(MapToViewModel).ToList();
            return View(restaurantsModel);
           
        }
        public ActionResult AddRestaurants()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurants(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                
                    var files = Request.Files;
                    if (files.Count > 0)
                    {
                        using (var filestream = files[0].InputStream)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                filestream.CopyTo(memoryStream);
                                model.Image = Convert.ToBase64String(memoryStream.ToArray());
                            }
                        }
                    }

                    Restaurant rest = new Restaurant
                {
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                    Email= model.Email,
                    Mobile = model.Mobile,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Image=model.Image,
                    RoleId=3

                };

                restaurantRepository.InsertRestaurant(rest);
                restaurantRepository.Save();

                return RedirectToAction("AllRestaurant"); 
            }

            return View(model);
        }
        //Edit
        public ActionResult EditRestaurant(int id)
        {
            var restaurant = restaurantRepository.GetRestaurantById(id);
            if (restaurant == null)
            {
                ModelState.AddModelError(string.Empty, "Product not found.");
                return View();
            }
           
            var viewModel = new Restaurant
            {
               RestId = id,
               Name = restaurant.Name,
               Address = restaurant.Address,
               Email = restaurant.Email,
               Mobile = restaurant.Mobile,
               City = restaurant.City,
               Latitude = restaurant.Latitude,
               Longitude = restaurant.Longitude,
               Image=restaurant.Image,
            };

            return View(viewModel);
        }
        

       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult EditRestaurant(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.RestId);
                var restaurant = restaurantRepository.GetRestaurantById(model.RestId);
                if (restaurant == null)
                {
                    ModelState.AddModelError(string.Empty, "restaurant not found.");
                    return View(model);
                }
                restaurant.Name = model.Name;
                restaurant.Address = model.Address;
                restaurant.Email = model.Email;
                restaurant.Mobile = model.Mobile;
                restaurant.Latitude = model.Latitude;
                restaurant.Longitude= model.Longitude;
                 try
                {
                    restaurantRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
                }
            }

            return View(model);
        }
        //Delete
        public ActionResult DeleteRest(int id)
        {
            var restaurant = restaurantRepository.GetRestaurantById(id);
            if (restaurant == null)
            {
                ModelState.AddModelError(string.Empty, "Restaurant not found.");
                return RedirectToAction("Index");
            }

            var viewModel = new Restaurant
            {
                RestId = id,
                Name = restaurant.Name,
                Address = restaurant.Address,
                Email = restaurant.Email,
                Mobile = restaurant.Mobile,
                Latitude = restaurant.Latitude,
                Longitude = restaurant.Longitude,
            };

            return View(viewModel);
        }
    
        [HttpPost, ActionName("DeleteRest")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRestConfirm(int id)
        {
            var restaurant = restaurantRepository.GetRestaurantById(id);
            if (restaurant == null)
            {
                ModelState.AddModelError(string.Empty, "Restaurant not found.");
                return RedirectToAction("Index");
            }
            restaurantRepository.DeleteRestaurant(restaurant.RestId);

            restaurantRepository.Save();
            TempData["SuccessMessage"] = "Restaurant deleted successfully.";
            return RedirectToAction("Index");
        }


        //MapToViewModel
        private Restaurant MapToViewModel(Restaurant restaurants)
        {
            return new Restaurant
            {
               RestId = restaurants.RestId,
               Name = restaurants.Name,
               Address = restaurants.Address,
               Email = restaurants.Email,
               Mobile = restaurants.Mobile,
               Latitude = restaurants.Latitude,
               Longitude = restaurants.Longitude,
               Image = restaurants.Image,
               City = restaurants.City,
            };
        }

        //User Crud

        public ActionResult AllUsers()
        {
            var userRepo = userRepository.GetAllUsers();
            var userModel = userRepo.Select(MapToViewModel).ToList();
            return View(userModel);

        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User model)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<User>();
               model.Password= passwordHasher.HashPassword(model, model.Password);
           
                User usr = new User
                {   FirstName=model.FirstName, 
                   LastName=model.LastName,
                   UserName = model.UserName,
                   Email = model.Email,
                   Mobile= model.Mobile,
                   Password = model.Password,
                   RoleId=2
                };

                userRepository.InsertUser(usr);
                userRepository.Save();

                return RedirectToAction("AllUsers");
            }

            return View(model);
        }
        public ActionResult EditUser(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return View();
            }

            var viewModel = new User
            {
              UserId = id,
              UserName=user.UserName,
              FirstName=user.FirstName,
              LastName=user.LastName,
              Email=user.Email,
              Mobile=user.Mobile,
              Password=user.Password,
              RoleId=user.RoleId
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.UserId);
                var user = userRepository.GetUserById(model.UserId);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "user not found.");
                    return View(model);
                }
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
             
                user.RoleId=model.RoleId;
                try
                {
                    userRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
                }
            }

            return View(model);
        }
        //Delete
        public ActionResult DeleteUsr(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Restaurant not found.");
                return RedirectToAction("Index");
            }

            var viewModel = new User
            {
                UserId = id,
                UserName = user.UserName,
                Email = user.Email,
                Mobile = user.Mobile,
                Password = user.Password,
                RoleId = user.RoleId,
                Role=user.Role
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteUsr")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserConfirm(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "user not found.");
                return RedirectToAction("Index");
            }
            userRepository.DeleteUser(user.UserId);

            userRepository.Save();
            TempData["SuccessMessage"] = "user deleted successfully.";
            return RedirectToAction("Index");
        }
        //MapToViewModel user
        private User MapToViewModel(User user)
        {
            return new User
            {
              UserId=user.UserId,
              UserName=user.UserName,
              Email=user.Email,
              Mobile=user.Mobile,
              Password=user.Password,
              RoleId=user.RoleId,
              Role=user.Role
                

            };
}

        //orders
        public ActionResult AllOrders()
        {
            var ordersRepo = orderRepository.GetAllOrders();
            var orderModel = ordersRepo.Select(MapToViewModel).ToList();
            return View(orderModel);

        }
        private  Order MapToViewModel(Order order)
        {
            return new Order
            {
              OrderId = order.OrderId,
              FoodItem = order.FoodItem,
              DeliveryCharge = order.DeliveryCharge,
              OrderStatus = order.OrderStatus,
              DateOfOrder = order.DateOfOrder,
              DeliveryAddress = order.DeliveryAddress,
              Qty = order.Qty,
              TotalAmount = order.TotalAmount,
              EstimatedDeliveryTime = order.EstimatedDeliveryTime,
              PaymentType = order.PaymentType,
              PaymentStatus = order.PaymentStatus,
              User=order.User,
              UserId=order.UserId,
          };
        }
        public ActionResult EditOrder(int oderId)
        {
            var ordersRepo = orderRepository.GetOrderById(oderId);
           
            return View(ordersRepo);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrder(Order model)
        {
            var orders1 = orderRepository.GetOrderById(model.OrderId);
          orders1.OrderStatus = model.OrderStatus;
            orders1.PaymentStatus = model.PaymentStatus;
            orderRepository.UpdateOrder(orders1);
            orderRepository.Save();
            return RedirectToAction("AllOrders");
        }
        //Ratings

        public ActionResult AllRating()
        {
            var ratingRepo = ratingRepository.GetAllRatings(); 
            var ratingModel = ratingRepo.Select(MapToViewModel).ToList();
            return View(ratingModel);

        }
        private Rating MapToViewModel(Rating rating)
        {
            return new Rating
            {
           RatingId = rating.RatingId,
           RatingCount = rating.RatingCount,
           Comments = rating.Comments,
           OrderId = rating.OrderId,
       
     
           UserId = rating.UserId,
           User= rating.User,
  
            };
        }
    }
}