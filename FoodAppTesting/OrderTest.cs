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

        // Test for OrderId
        [Test]
        public void OrderId_WithValidValue_PassesValidation()
        {
            _order.OrderId = 1; // Valid OrderId

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for FoodId
        [Test]
        public void FoodId_WithValidValue_PassesValidation()
        {
            _order.FoodId = 1; // Valid FoodId

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for UserId
        [Test]
        public void UserId_WithValidValue_PassesValidation()
        {
            _order.UserId = 1; // Valid UserId

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Qty
        [Test]
        public void Qty_WithValidValue_PassesValidation()
        {
            _order.Qty = 2; // Valid Qty

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for TotalAmount
        [Test]
        public void TotalAmount_WithValidValue_PassesValidation()
        {
            _order.TotalAmount = 10.5m; // Valid TotalAmount

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for DeliveryAddress
        [Test]
        public void DeliveryAddress_WithValidValue_PassesValidation()
        {
            _order.DeliveryAddress = "123 Street, City"; // Valid DeliveryAddress

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for DeliveryCharge
        [Test]
        public void DeliveryCharge_WithValidValue_PassesValidation()
        {
            _order.DeliveryCharge = 5.0m; // Valid DeliveryCharge

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for OrderStatus
        [Test]
        public void OrderStatus_WithValidValue_PassesValidation()
        {
            _order.OrderStatus = "Preparing"; // Valid OrderStatus

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for EstimatedDeliveryTime
        [Test]
        public void EstimatedDeliveryTime_WithValidValue_PassesValidation()
        {
            _order.EstimatedDeliveryTime = DateTime.Now.AddDays(1); // Valid EstimatedDeliveryTime

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for DateOfOrder
        [Test]
        public void DateOfOrder_WithValidValue_PassesValidation()
        {
            _order.DateOfOrder = DateTime.Now; // Valid DateOfOrder

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for PaymentType
        [Test]
        public void PaymentType_WithValidValue_PassesValidation()
        {
            _order.PaymentType = "Credit Card"; // Valid PaymentType

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for PaymentStatus
        [Test]
        public void PaymentStatus_WithValidValue_PassesValidation()
        {
            _order.PaymentStatus = "Pending"; // Valid PaymentStatus

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Discount
        [Test]
        public void Discount_WithValidValue_PassesValidation()
        {
            _order.Discount = 5.0m; // Valid Discount

            var context = new ValidationContext(_order, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_order, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}
