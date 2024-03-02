using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void InsertOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        void Save();
    }
}
