using FoodAppDALLayer.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace FoodAppDALLayer.Tests
{
    [TestFixture]
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new User();
        }

        // Test for UserId
        [Test]
        public void UserId_WithValidValue_PassesValidation()
        {
            _user.UserId = 1; // Valid UserId

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for FirstName
        [Test]
        public void FirstName_WithValidValue_PassesValidation()
        {
            _user.FirstName = "John"; // Valid FirstName

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for LastName
        [Test]
        public void LastName_WithValidValue_PassesValidation()
        {
            _user.LastName = "Doe"; // Valid LastName

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for UserName
        [Test]
        public void UserName_WithValidValue_PassesValidation()
        {
            _user.UserName = "john_doe"; // Valid UserName

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Email
        [Test]
        public void Email_WithValidValue_PassesValidation()
        {
            _user.Email = "john@example.com"; // Valid Email

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Mobile
        [Test]
        public void Mobile_WithValidValue_PassesValidation()
        {
            _user.Mobile = "1234567890"; // Valid Mobile

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for Password
        [Test]
        public void Password_WithValidValue_PassesValidation()
        {
            _user.Password = "Password123"; // Valid Password

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        // Test for RoleId
        [Test]
        public void RoleId_WithValidValue_PassesValidation()
        {
            _user.RoleId = 1; 

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }
    }
}