using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAppUILayer.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        public UserController()
        {

        }
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFoodItemRepository foodItemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IRestaurantRepository restaurantRepository;


        public UserController(IRestaurantRepository restaurantRepository, ICategoryRepository categoryRepository, IFoodItemRepository foodItemRepository)
        {
            this.foodItemRepository = foodItemRepository ?? throw new ArgumentNullException(nameof(foodItemRepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        }

        public ActionResult AllRestaurant()
        {

            var rest = restaurantRepository.GetAllRestaurants();
          
            var restaurantModel = rest.Select(MapToViewModel).ToList();

            return View(restaurantModel);
        }
        private Restaurant MapToViewModel(Restaurant rest)
        {
            return new Restaurant
            {
            RestId = rest.RestId,
            Name = rest.Name,
            Address = rest.Address,
            City = rest.City,
            Email = rest.Email,
            Mobile = rest.Mobile,
            Latitude = rest.Latitude,
            Longitude = rest.Longitude, 
            Image = rest.Image,

            };
        }
    }
}