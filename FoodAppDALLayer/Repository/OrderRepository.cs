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
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Find(id);
        }

        public void InsertOrder(Order order)
        {
            _context.Orders.Add(order);
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
