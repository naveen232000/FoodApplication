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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly FoodAppDbContext _context;

        public OrderItemRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public OrderItem GetById(int id)
        {
            return _context.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public void Update(OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var orderItem = _context.OrderItems.Find(id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
