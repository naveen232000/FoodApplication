using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IFoodItemRepository
    {
        IEnumerable<FoodItem> GetAllFoodItems();
        FoodItem GetFoodItemById(int id);
        IEnumerable<FoodItem> GetFoodItemByRestId(int restid);
       
        void InsertFoodItem(FoodItem foodItem);
        void DeleteFoodItem(int id);
        void UpdateFoodItem(FoodItem foodItem);
        void Save();
    }
}
