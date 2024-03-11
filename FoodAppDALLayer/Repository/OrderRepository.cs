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
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodAppDbContext _context;

        public OrderRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(r => r.FoodItem).ToList();
        }
        public IEnumerable<Order> GetTop5OrdersByFoodId()
        {
            var top5Orders = _context.Orders
                                 .GroupBy(o => o.FoodItem)
                                 .SelectMany(group => group.OrderByDescending(o => group.Count()).Take(4))
                                 .Include(r => r.FoodItem)
                                 .ToList();
            var distinctTop5Orders = top5Orders.GroupBy(o => o.FoodId).Select(g => g.First()).ToList();

            return distinctTop5Orders;
        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }
        public IEnumerable<Order> GetOrderByodId(int id)
        {
            var item = _context.Orders.Include(r => r.FoodItem).Where(a => a.OrderId == id);
            return item;
        }
        public IEnumerable<Order> GetOrderByRestId(int id)
        {
            var item = _context.Orders.Include(r => r.FoodItem).Where(a => a.FoodItem.RestId == id);
            return item;
        }
        public IEnumerable<Order> GetOrderByUserId(int id)
        {
            var item = _context.Orders.Include(r => r.FoodItem).Where(a => a.UserId == id);
            return item;
        }
        public int GetOrderCountByUserId(int id)
        {
            return _context.Orders.Count(o => o.UserId == id);
        }

        public int InsertOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges(); 
            return order.OrderId;
        }

        public void DeleteOrder(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
