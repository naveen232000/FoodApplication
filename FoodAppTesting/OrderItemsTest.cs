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
    public class OrderItemTests
    {
        private OrderItem _orderItem;

        [SetUp]
        public void SetUp()
        {
            _orderItem = new OrderItem();
        }

      
        [Test]
        public void OrderItemId_WithValidValue_PassesValidation()
        {
            _orderItem.OrderItemId = 1; 

            var context = new ValidationContext(_orderItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_orderItem, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void OrderId_WithValidValue_PassesValidation()
        {
            _orderItem.OrderId = 1; 

            var context = new ValidationContext(_orderItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_orderItem, context, results, true);

            Assert.IsFalse(isValid);
        }

  
        [Test]
        public void FoodId_WithValidValue_PassesValidation()
        {
            _orderItem.FoodId = 1; 

            var context = new ValidationContext(_orderItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_orderItem, context, results, true);

            Assert.IsFalse(isValid);
        }

    
        [Test]
        public void Quantity_WithValidValue_PassesValidation()
        {
            _orderItem.Quantity = 2;

            var context = new ValidationContext(_orderItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_orderItem, context, results, true);

            Assert.IsTrue(isValid);
        }


        [Test]
        public void Price_WithValidValue_PassesValidation()
        {
            _orderItem.Price = 10.5m; 

            var context = new ValidationContext(_orderItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_orderItem, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}
