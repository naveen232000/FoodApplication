using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAppUILayer.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {

        }
        private readonly IRatingRepository ratingRepository;
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IOrderRepository orderRepository;

        public AdminController(IRatingRepository ratingRepository, IRestaurantRepository restaurantRepository, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            this.ratingRepository = ratingRepository ?? throw new ArgumentNullException(nameof(ratingRepository));
            this.restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

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
               
                // Create a Product entity from the ViewModel
                Restaurant rest = new Restaurant
                {
                    Name = model.Name,
                    Address = model.Address,
                    Email= model.Email,
                    Mobile = model.Mobile,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,

                };

                // Add the product to the database
                restaurantRepository.InsertRestaurant(rest);
                restaurantRepository.Save();

                return RedirectToAction("AllRestaurant"); // Redirect to the product list page
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
               Latitude = restaurant.Latitude,
               Longitude = restaurant.Longitude,
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
            };
        }
    }
}