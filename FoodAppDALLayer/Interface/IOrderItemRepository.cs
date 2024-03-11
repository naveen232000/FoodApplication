using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IOrderItemRepository
    {
        OrderItem GetById(int id);
        IEnumerable<OrderItem> GetAll();
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(int id);
        void SaveChanges();
    }
}
