using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodAppDbContext _context;

        public FoodItemRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodItem> GetAllFoodItems()
        {
            return _context.FoodItems.ToList();
        }

        public FoodItem GetFoodItemById(int id)
        {
            return _context.FoodItems.Find(id);
        }
        public IEnumerable<FoodItem> GetFoodItemByRestId(int restid)
        {
            var item = _context.FoodItems.Include(r => r.Category).Where(a => a.RestId == restid);
            return item;
        }

        public void InsertFoodItem(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);
        }

        public void DeleteFoodItem(int id)
        {
            FoodItem foodItem = _context.FoodItems.Find(id);
            _context.FoodItems.Remove(foodItem);
        }

        public void UpdateFoodItem(FoodItem foodItem)
        {
            _context.Entry(foodItem).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
      
    }
}
