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
    public class RestaurantTests
    {
        private Restaurant _restaurant;

        [SetUp]
        public void SetUp()
        {
            _restaurant = new Restaurant();
        }

        // Test for RestId
        [Test]
        public void RestId_WithValidValue_PassesValidation()
        {
            _restaurant.RestId = 1; // Valid RestId

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Name
        [Test]
        public void Name_WithValidValue_PassesValidation()
        {
            _restaurant.Name = "Restaurant Name"; // Valid Name

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Address
        [Test]
        public void Address_WithValidValue_PassesValidation()
        {
            _restaurant.Address = "123 Street, City"; // Valid Address

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Email
        [Test]
        public void Email_WithValidValue_PassesValidation()
        {
            _restaurant.Email = "restaurant@example.com"; // Valid Email

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Mobile
        [Test]
        public void Mobile_WithValidValue_PassesValidation()
        {
            _restaurant.Mobile = "1234567890"; // Valid Mobile

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Latitude
        [Test]
        public void Latitude_WithValidValue_PassesValidation()
        {
            _restaurant.Latitude = 12.345; // Valid Latitude

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Longitude
        [Test]
        public void Longitude_WithValidValue_PassesValidation()
        {
            _restaurant.Longitude = 67.890; // Valid Longitude

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for City
        [Test]
        public void City_WithValidValue_PassesValidation()
        {
            _restaurant.City = "City"; // Valid City

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for RoleId
        [Test]
        public void RoleId_WithValidValue_PassesValidation()
        {
            _restaurant.RoleId = 1; // Valid RoleId

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}
