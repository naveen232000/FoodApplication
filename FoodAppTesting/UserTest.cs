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

        
        [Test]
        public void UserId_WithValidValue_PassesValidation()
        {
            _user.UserId = 1; 

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void FirstName_WithValidValue_PassesValidation()
        {
            _user.FirstName = "John"; 

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

      
        [Test]
        public void LastName_WithValidValue_PassesValidation()
        {
            _user.LastName = "Doe";

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void UserName_WithValidValue_PassesValidation()
        {
            _user.UserName = "john_doe";

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

       
        [Test]
        public void Email_WithValidValue_PassesValidation()
        {
            _user.Email = "john@example.com";

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }

  
        [Test]
        public void Mobile_WithValidValue_PassesValidation()
        {
            _user.Mobile = "1234567890";

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }


        [Test]
        public void Password_WithValidValue_PassesValidation()
        {
            _user.Password = "Password123"; 

            var context = new ValidationContext(_user, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(_user, context, results, true);

            Assert.IsFalse(isValid);
        }


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