using FoodAppDALLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppTesting
{
    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [SetUp]
        public void SetUp()
        {
            _order = new Order();
        }

       
        [Test]
        public void OrderId_WithValidValue_PassesValidation()
        {
            _order.OrderId = 1; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void FoodId_WithValidValue_PassesValidation()
        {
            _order.FoodId = 1; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

     
        [Test]
        public void UserId_WithValidValue_PassesValidation()
        {
            _order.UserId = 1;

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

   
        [Test]
        public void Qty_WithValidValue_PassesValidation()
        {
            _order.Qty = 2; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

      
        [Test]
        public void TotalAmount_WithValidValue_PassesValidation()
        {
            _order.TotalAmount = 10.5m; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void DeliveryAddress_WithValidValue_PassesValidation()
        {
            _order.DeliveryAddress = "123 Street, City"; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void DeliveryCharge_WithValidValue_PassesValidation()
        {
            _order.DeliveryCharge = 5.0m;

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

    
        [Test]
        public void OrderStatus_WithValidValue_PassesValidation()
        {
            _order.OrderStatus = "Preparing"; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void EstimatedDeliveryTime_WithValidValue_PassesValidation()
        {
            _order.EstimatedDeliveryTime = DateTime.Now.AddDays(1); 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

  
        [Test]
        public void DateOfOrder_WithValidValue_PassesValidation()
        {
            _order.DateOfOrder = DateTime.Now; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void PaymentType_WithValidValue_PassesValidation()
        {
            _order.PaymentType = "Credit Card"; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void PaymentStatus_WithValidValue_PassesValidation()
        {
            _order.PaymentStatus = "Pending"; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Discount_WithValidValue_PassesValidation()
        {
            _order.Discount = 5.0m; 

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}
