using FoodAppDALLayer.ApplicationDbContext;
using FoodAppDALLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodAppTesting
{
    [TestFixture]
    public class Tests
    {
        private FoodAppDbContext foodAppDbContext;
        [SetUp]
        public void Setup()
        {
            foodAppDbContext = new FoodAppDbContext();
        }



        //[Test]
        //public void EmailIsRequired()
        //{
        //    // Arrange
        //    var admin = new Admin();

        //    // Act
        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

        //    // Assert
        //    Assert.IsFalse(isValid);
        //    Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The Email field is required."));
        //}

        //[Test]
        //public void EmailValidation()
        //{
        //    // Arrange
        //    var admin = new Admin { Email = "invalidemail" };

        //    // Act
        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

        //    // Assert
        //    Assert.IsFalse(isValid);
        //    Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The Email field is not a valid e-mail address."));
        //}

        //[Test]
        //public void PhoneIsRequired()
        //{
        //    // Arrange
        //    var admin = new Admin();

        //    // Act
        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

        //    // Assert
        //    Assert.IsFalse(isValid);
        //    Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The Phone Number field is required."));
        //}


        [Test]
        public void IdIsRequired()
        {
            // Arrange
            var admin = new Admin();

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The Id field is required."));
        }

        [Test]
        public void EmailIsRequired()
        {
            // Arrange
            var admin = new Admin();

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The Email field is required."));
        }

        [Test]
        public void EmailValidation()
        {
            // Arrange
            var admin = new Admin { Email = "invalidemail" };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The Email field is not a valid e-mail address."));
        }

        [Test]
        public void PhoneNumberIsRequired()
        {
            // Arrange
            var admin = new Admin();

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The PhoneNumber field is required."));
        }

        [Test]
        public void PhoneNumberValidation()
        {
            // Arrange
            var admin = new Admin { PhoneNumber = "1234567" }; // Invalid phone number format

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "Not a valid phone number"));
        }

        [Test]
        public void UserNameIsRequired()
        {
            // Arrange
            var admin = new Admin();

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "The UserName field is required."));
        }

        [Test]
        public void PasswordIsRequired()
        {
            // Arrange
            var admin = new Admin (); // Invalid password 

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Exists(v => v.ErrorMessage == "Please Enter Password"));
        }


    }
}