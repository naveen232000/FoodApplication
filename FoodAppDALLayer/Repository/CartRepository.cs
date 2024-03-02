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
    public class CartRepository : ICartRepository
    {
        private readonly FoodAppDbContext _context;

        public CartRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _context.Carts.ToList();
        }

        public Cart GetCartById(int id)
        {
            return _context.Carts.Find(id);
        }

        public void InsertCart(Cart cart)
        {
            _context.Carts.Add(cart);
        }

        public void DeleteCart(int id)
        {
            Cart cart = _context.Carts.Find(id);
            _context.Carts.Remove(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
