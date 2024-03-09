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
    public class RatingRepository : IRatingRepository
    {
        private readonly FoodAppDbContext _context;

        public RatingRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rating> GetAllRatings()
        {
            return _context.Ratings.Include(u => u.User).ToList();
        }

        public Rating GetRatingById(int id)
        {
            return _context.Ratings.Find(id);
        }

        public void InsertRating(Rating rating)
        {
            _context.Ratings.Add(rating);
        }

        public void DeleteRating(int id)
        {
            Rating rating = _context.Ratings.Find(id);
            _context.Ratings.Remove(rating);
        }

        public void UpdateRating(Rating rating)
        {
            _context.Entry(rating).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
