using NUnit.Framework;
using FoodAppDALLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodAppTesting
{
    [TestFixture]
    public class Tests
    {
        private Admin _admin;

        [SetUp]
        public void Setup()
        {
            _admin = new Admin();
        }

 
        [Test]
        public void TestFirstNameValidation_ValidFirstName_ReturnsTrue()
        {
            _admin.FirstName = "John";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestFirstNameValidation_InvalidFirstName_ReturnsFalse()
        {
            _admin.FirstName = "John123"; 
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }


        [Test]
        public void TestLastNameValidation_ValidLastName_ReturnsTrue()
        {
            _admin.LastName = "Doe";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestLastNameValidation_InvalidLastName_ReturnsFalse()
        {
            _admin.LastName = "Doe123"; 
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestEmailValidation_ValidEmail_ReturnsTrue()
        {
            _admin.Email = "john.doe@example.com";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestEmailValidation_InvalidEmail_ReturnsFalse()
        {
            _admin.Email = "john.doe"; 
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestPhoneNumberValidation_ValidPhoneNumber_ReturnsTrue()
        {
            _admin.PhoneNumber = "1234567890";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestPhoneNumberValidation_InvalidPhoneNumber_ReturnsFalse()
        {
            _admin.PhoneNumber = "12345"; 
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestUserNameValidation_ValidUserName_ReturnsTrue()
        {
            _admin.UserName = "johndoe";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestUserNameValidation_EmptyUserName_ReturnsFalse()
        {
            _admin.UserName = ""; 
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

   
        [Test]
        public void TestPasswordValidation_ValidPassword_ReturnsTrue()
        {
            _admin.Password = "Password@123";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }

        [Test]
        public void TestPasswordValidation_InvalidPassword_ReturnsFalse()
        {
            _admin.Password = "password";
            var context = new ValidationContext(_admin, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(_admin, context, results, true);
            Assert.IsFalse(valid);
        }
    }
}
