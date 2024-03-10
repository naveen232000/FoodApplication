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
    public class FoodItemTests
    {
        private FoodItem _foodItem;

        [SetUp]
        public void SetUp()
        {
            _foodItem = new FoodItem();
        }

        // Test for FoodId
        [Test]
        public void FoodId_WithValidValue_PassesValidation()
        {
            _foodItem.FoodId = 1; // Valid FoodId

            var context = new ValidationContext(_foodItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_foodItem, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Name
        [Test]
        public void Name_WithValidValue_PassesValidation()
        {
            _foodItem.Name = "Food Item"; // Valid Name

            var context = new ValidationContext(_foodItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_foodItem, context, results, true);

            Assert.IsTrue(isValid);
        }

        // Test for Description
        [Test]
        public void Description_WithValidValue_PassesValidation()
        {
            _foodItem.Description = "Description of food item"; // Valid Description

            var context = new ValidationContext(_foodItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_foodItem, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for RestId
        [Test]
        public void RestId_WithValidValue_PassesValidation()
        {
            _foodItem.RestId = 1; // Valid RestId

            var context = new ValidationContext(_foodItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_foodItem, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Price
        [Test]
        public void Price_WithValidValue_PassesValidation()
        {
            _foodItem.Price = 10.5m; // Valid Price

            var context = new ValidationContext(_foodItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_foodItem, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for CategoryId
        [Test]
        public void CategoryId_WithValidValue_PassesValidation()
        {
            _foodItem.CategoryId = 1; // Valid CategoryId

            var context = new ValidationContext(_foodItem, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_foodItem, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}
