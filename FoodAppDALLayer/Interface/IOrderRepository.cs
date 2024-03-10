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
        IEnumerable<Order> GetTop5OrdersByFoodId();
        Order GetOrderById(int id);
        IEnumerable<Order> GetOrderByRestId(int id);
        IEnumerable<Order> GetOrderByodId(int id);
        int GetOrderCountByUserId(int id);
        IEnumerable<Order> GetOrderByUserId(int id);
        int InsertOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        void Save();
    }
}
