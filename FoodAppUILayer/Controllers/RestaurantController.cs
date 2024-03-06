using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppDALLayer.Repository;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace FoodAppUILayer.Controllers
{
    public class RestaurantController : Controller
    {
        public RestaurantController()
        {

        }
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFoodItemRepository foodItemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IRestaurantRepository restaurantRepository;
 

        public RestaurantController(IRestaurantRepository restaurantRepository, ICategoryRepository categoryRepository, IFoodItemRepository foodItemRepository)
        {
            this.foodItemRepository = foodItemRepository ?? throw new ArgumentNullException(nameof(foodItemRepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        }

        public ActionResult AllFoodItems()
        {
            var foodItem = foodItemRepository.GetAllFoodItems();
            var foodIteamModel = foodItem.Select(MapToViewModel).ToList();
            return View(foodIteamModel);

        }
   

        //Addproduct
        public ActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFood(FoodItem model)
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
                            // Convert byte array to Base64 String
                            model.Image = Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
                try
                {
                    FoodItem food = new FoodItem
                    {
                        FoodId = model.FoodId,
                        Name = model.Name,
                        Availability = model.Availability,
                        Description = model.Description,
                        Price = model.Price,
                        Image = model.Image,
                        CategoryId = model.CategoryId,
                        RestId = model.RestId,

                    };
                    foodItemRepository.InsertFoodItem(food);
                    foodItemRepository.Save();
                    return RedirectToAction("AllFoodItems");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error occurred while saving data: " + ex.Message);
                    // Log the exception for debugging purposes
                }

                return View(model);
            }
            return View(model);
        }

        public ActionResult EditFoodItem(int id)
        {
            var foodItem = foodItemRepository.GetFoodItemById(id);
            if (foodItem == null)
            {
                ModelState.AddModelError(string.Empty, "Food item not found.");
                return View();
            }

            var viewModel = new FoodItem
            {
              FoodId=foodItem.FoodId,
              Name=foodItem.Name,
              Availability=foodItem.Availability,
              Description=foodItem.Description,
              Price =foodItem.Price,
              Image =foodItem.Image,
              CategoryId =foodItem.CategoryId,
              RestId =foodItem.RestId,

            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFoodItem(FoodItem model)
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
                            // Convert byte array to Base64 String
                            model.Image = Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
                Console.WriteLine(model.RestId);
                var foodItem = foodItemRepository.GetFoodItemById(model.RestId);
                if (foodItem == null)
                {
                    ModelState.AddModelError(string.Empty, "FoodItem not found.");
                    return View(model);
                }
                foodItem.Name = model.Name;
                foodItem.Availability = model.Availability;
                foodItem.Description = model.Description;
                foodItem.Price = model.Price;
                foodItem.Image = model.Image;
                foodItem.CategoryId = model.CategoryId;
                foodItem.RestId = model.RestId;
               
                try
                {
                    foodItemRepository.Save();
                    return RedirectToAction("AllFoodItems");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
                }
            }

            return View(model);
        }
        public ActionResult DeleteFood(int id)
        {
            var foodItem = foodItemRepository.GetFoodItemById(id);
            if (foodItem == null)
            {
                ModelState.AddModelError(string.Empty, "FoodItem not found.");
                return RedirectToAction("Index");
            }

            var viewModel = new FoodItem
            {
              FoodId = id,
              Name=foodItem.Name,
              Description=foodItem.Description,
              Price=foodItem.Price,
              Image = foodItem.Image,
              CategoryId=foodItem.CategoryId,
              RestId=foodItem.RestId,

            };

            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteFood")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFoodConfirm(int id)
        {
            var foodItem = foodItemRepository.GetFoodItemById(id);
            if (foodItem == null)
            {
                ModelState.AddModelError(string.Empty, "Restaurant not found.");
                return RedirectToAction("Index");
            }
            foodItemRepository.DeleteFoodItem(foodItem.FoodId);

            foodItemRepository.Save();
            TempData["SuccessMessage"] = "FoodItem deleted successfully.";
            return RedirectToAction("AllFoodItems");
        }

        //MapToViewModel
        private FoodItem MapToViewModel(FoodItem foodItem)
        {
            return new FoodItem
            {
                FoodId = foodItem.FoodId,
                Availability = foodItem.Availability,
                Name = foodItem.Name,
                Image = foodItem.Image,
                Category = foodItem.Category,
                Description = foodItem.Description,
                Restaurant = foodItem.Restaurant,
                RestId = foodItem.RestId,
                Price = foodItem.Price,
            };
        }



    }
}