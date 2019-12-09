using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Authentication;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class UserServiceTest
    {
        [Fact]
        public void Validate_LoginInputModelValid_ReturnsUserWithSpecifiedCredentials()
        {
            //Arrange
            LoginInputModel validLoginInputModel = new LoginInputModel
            {
                Username = "admin",
                Password = "admin"
            };

            User expected = new User
            {
                Id = 1,
                Username = validLoginInputModel.Username,
                IsAdmin = true
            };

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                expected.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(validLoginInputModel.Password));
                expected.PasswordSalt = hmac.Key;
            }

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(repo => repo.Read(validLoginInputModel.Username)).
                Returns(expected);

            IUserService userService = new UserService(userRepository.Object);

            //Act
            User actual = userService.Validate(validLoginInputModel);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Validate_LoginInputModelNull_ThrowsArgumentNullException()
        {
            //Arrange
            LoginInputModel invalidLoginInputModel = null;

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

            IUserService userService = new UserService(userRepository.Object);

            //Act
            Action actual = () => userService.Validate(invalidLoginInputModel);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Validate_UsernameNull_ThrowsArgumentException()
        {
            //Arrange
            LoginInputModel invalidLoginInputModel = new LoginInputModel
            {
                Username = null,
                Password = "admin"
            };

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

            IUserService userService = new UserService(userRepository.Object);

            //Act
            Action actual = () => userService.Validate(invalidLoginInputModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Validate_UsernameEmpty_ThrowsArgumentException()
        {
            //Arrange
            LoginInputModel invalidLoginInputModel = new LoginInputModel
            {
                Username = "",
                Password = "admin"
            };

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

            IUserService userService = new UserService(userRepository.Object);

            //Act
            Action actual = () => userService.Validate(invalidLoginInputModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Validate_PasswordNull_ThrowsArgumentException()
        {
            //Arrange
            LoginInputModel invalidLoginInputModel = new LoginInputModel
            {
                Username = "admin",
                Password = null
            };

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

            IUserService userService = new UserService(userRepository.Object);

            //Act
            Action actual = () => userService.Validate(invalidLoginInputModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Validate_PasswordEmpty_ThrowsArgumentException()
        {
            //Arrange
            LoginInputModel invalidLoginInputModel = new LoginInputModel
            {
                Username = "admin",
                Password = ""
            };

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

            IUserService userService = new UserService(userRepository.Object);

            //Act
            Action actual = () => userService.Validate(invalidLoginInputModel);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }
    }
}
