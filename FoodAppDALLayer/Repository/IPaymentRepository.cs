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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FoodAppDbContext _context;

        public PaymentRepository(FoodAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return _context.Payments.Find(id);
        }

        public void InsertPayment(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public void DeletePayment(int id)
        {
            Payment payment = _context.Payments.Find(id);
            _context.Payments.Remove(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
