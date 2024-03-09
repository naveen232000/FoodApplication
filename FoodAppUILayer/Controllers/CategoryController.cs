using FoodAppDALLayer.Interface;
using FoodAppDALLayer;
using FoodAppDALLayer.Repository;
using FoodAppUILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodAppDALLayer.Models;

namespace FoodAppUILayer.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;



        public CategoryController(ICategoryRepository category)
        {
            this._categoryRepository = category;
        }
        public ActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAllCategories();
            IEnumerable<CategoryViewModel> categorieViewModels = categories.Select(cat => new CategoryViewModel
            {
                CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName,
            });
            return View(categorieViewModels);
        }


        public ActionResult AddCategory()
        {
            int nextCategoryId = _categoryRepository.GetLastCategoryId() + 1;
            CategoryViewModel newCategory = new CategoryViewModel
            {
                CategoryId = nextCategoryId
            };
            return View(newCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                if (!_categoryRepository.CategoryExists(category.CategoryName))
                {
                    // If it doesn't exist, proceed to add the new category
                    Category categoryToSave = new Category
                    {
                        CategoryName = category.CategoryName
                    };

                    _categoryRepository.SaveCategory(categoryToSave);
                }
                else
                {
                    // Handle the case where the category already exists (e.g., show an error message)
                    ModelState.AddModelError("CategoryName", "Category with this name already exists.");
                    return View(category);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            // Retrieve the category from the repository based on the id
            Category category = _categoryRepository.GetCategoryById(id);
     
            // Check if the category exists
            if (category == null)
            {
                return HttpNotFound(); // Handle the case where the category is not found
            }

            // Map the Category model to the CategoryModel if needed
            CategoryViewModel categoryModelView = new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };

            return View(categoryModelView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the existing category from the repository
                Category existingCategory = _categoryRepository.GetCategoryById(categoryViewModel.CategoryId);

                // Check if the category exists
                if (existingCategory == null)
                {
                    return HttpNotFound(); // Handle the case where the category is not found
                }


                if (_categoryRepository.CategoryExists(categoryViewModel.CategoryName, categoryViewModel.CategoryId))
                {
                    // Update the properties of the existing category
                    existingCategory.CategoryName = categoryViewModel.CategoryName;

                    // Save the changes to the repository
                    _categoryRepository.UpdateCategory(existingCategory);

                    return RedirectToAction("Index"); // Redirect to the category list or another appropriate action
                }
                else
                {
                    // Handle the case where the category already exists (e.g., show an error message)
                    ModelState.AddModelError("CategoryName", "Category with this name already exists.");
                }
            }

            // If the model state is not valid, redisplay the edit view
            return View("EditCategory", categoryViewModel);
        }

        public ActionResult DeleteCategory(int id)
        {

            Category categoryToDelete = _categoryRepository.GetCategoryById(id);
            if (categoryToDelete != null)
            {

                _categoryRepository.DeleteCategory(categoryToDelete);

            }
            
            return RedirectToAction("Index");
        }
    }
}