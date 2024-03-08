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
        Cart GetCartItemByfIdUid(int foodId, int userId);
        List<Cart> GetCartItemsByUserId(int? userId);
        Cart GetCartItemByCartIdUid(int catrId, int userId);
        IEnumerable<Cart> GetCartItemById(int[] cartIds);
        void InsertCart(Cart cart);
        void DeleteCart(int id);
        void UpdateCart(Cart cart);
        void Save();
    }
}
