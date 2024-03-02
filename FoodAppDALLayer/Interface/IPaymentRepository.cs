using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Interface
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void InsertPayment(Payment payment);
        void DeletePayment(int id);
        void UpdatePayment(Payment payment);
        void Save();
    }
}
