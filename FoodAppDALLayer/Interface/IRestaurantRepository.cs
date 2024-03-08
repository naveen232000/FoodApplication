using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantById(int id);
        Restaurant GetRestaurantByemail(string email);
        void InsertRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int id);
        void UpdateRestaurant(Restaurant restaurant);
        void Save();
        void Detach(Restaurant rest);
    }
}
