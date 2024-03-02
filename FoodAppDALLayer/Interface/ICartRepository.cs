using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAllCarts();
        Cart GetCartById(int id);
        void InsertCart(Cart cart);
        void DeleteCart(int id);
        void UpdateCart(Cart cart);
        void Save();
    }
}
