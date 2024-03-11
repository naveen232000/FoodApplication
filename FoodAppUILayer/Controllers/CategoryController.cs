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
                  
                    Category categoryToSave = new Category
                    {
                        CategoryName = category.CategoryName
                    };

                    _categoryRepository.SaveCategory(categoryToSave);
                }
                else
                {
                    ModelState.AddModelError("CategoryName", "Category with this name already exists.");
                    return View(category);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
     
            if (category == null)
            {
                return HttpNotFound(); 
            }
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
                Category existingCategory = _categoryRepository.GetCategoryById(categoryViewModel.CategoryId);

                if (existingCategory == null)
                {
                    return HttpNotFound(); 
                }


                if (_categoryRepository.CategoryExists(categoryViewModel.CategoryName, categoryViewModel.CategoryId))
                {
                    existingCategory.CategoryName = categoryViewModel.CategoryName;

                    _categoryRepository.UpdateCategory(existingCategory);

                    return RedirectToAction("Index"); 
                }
                else
                {
                    ModelState.AddModelError("CategoryName", "Category with this name already exists.");
                }
            }

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