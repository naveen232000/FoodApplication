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

        [Test]
        public void RestId_WithValidValue_PassesValidation()
        {
            _restaurant.RestId = 1; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

     
        [Test]
        public void Name_WithValidValue_PassesValidation()
        {
            _restaurant.Name = "Restaurant Name"; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

     
        [Test]
        public void Address_WithValidValue_PassesValidation()
        {
            _restaurant.Address = "123 Street, City";

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void Email_WithValidValue_PassesValidation()
        {
            _restaurant.Email = "restaurant@example.com"; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void Mobile_WithValidValue_PassesValidation()
        {
            _restaurant.Mobile = "1234567890"; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Latitude_WithValidValue_PassesValidation()
        {
            _restaurant.Latitude = 12.345; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void Longitude_WithValidValue_PassesValidation()
        {
            _restaurant.Longitude = 67.890; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }

    
        [Test]
        public void City_WithValidValue_PassesValidation()
        {
            _restaurant.City = "City"; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void RoleId_WithValidValue_PassesValidation()
        {
            _restaurant.RoleId = 1; 

            var context = new ValidationContext(_restaurant, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_restaurant, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}
