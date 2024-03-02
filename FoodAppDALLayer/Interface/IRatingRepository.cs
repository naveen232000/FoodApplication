using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetAllRatings();
        Rating GetRatingById(int id);
        void InsertRating(Rating rating);
        void DeleteRating(int id);
        void UpdateRating(Rating rating);
        void Save();
    }
}
