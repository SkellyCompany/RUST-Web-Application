using System;
using Moq;
using Xunit;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Order;

namespace RUSTWebApplication.UnitTests.Core
{
    public class CountryServiceTest
    {
        [Fact]
        public void Create_CountryValid_ReturnsCreatedCountryWithId()
        {
            //Arrange
            Country validCountry = new Country { Name = "Netherlands" };
            Country expected = new Country { Id = 1, Name = validCountry.Name };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Create(validCountry)).
                Returns(expected);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Country actual = countryService.Create(validCountry);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_CountryNull_ThrowsArgumentNullException()
        {
            //Arrange
            Country invalidCountry = null;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arrange
            Country invalidCountry = new Country { Id = 1, Name = "Netherlands" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameNull_ThrowsArgumentException()
        {
            //Arrange
            Country invalidCountry = new Country { };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            Country invalidCountry = new Country { Name = ""};

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_NameLowerCased_ThrowsArgumentException()
        {
            //Arrange
            Country invalidCountry = new Country { Name = "netherlands" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Read_IdExisting_ReturnsCountryWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            Country expected = new Country { Id = existingId, Name = "Denmark" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Read(existingId)).
                Returns(expected);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Country actual = countryService.Read(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            Country expected = null;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Read(nonExistingId)).
                Returns(expected);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Country actual = countryService.Read(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_CountryValid_ReturnsUpdatedCountry()
        {
            //Arrange
            Country validCountry = new Country{Id = 4, Name = "Poland" };
            Country expected = validCountry;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Read(validCountry.Id)).
                Returns(validCountry);
            countryRepository.Setup(repo => repo.Update(validCountry)).
                Returns(expected);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Country actual = countryService.Update(validCountry);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_CountryNull_ThrowsArgumentNullException()
        {
            //Arrange
            Country invalidCountry = null;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Update(invalidCountry);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Update_IdNonExisting_ThrowsArgumentException()
        {
            //Arrange
            Country nonExistingCountry = new Country{ Id = 4, Name = "Greece" };
            Country nullProductCategory = null;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Read(nonExistingCountry.Id)).
                Returns(nullProductCategory);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Update(nonExistingCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameNull_ThrowsArgumentException()
        {
            //Arrange
            Country invalidCountry = new Country{ Id = 4, Name = null };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Update(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Update_NameEmpty_ThrowsArgumentException()
        {
            //Arrange
            Country invalidCountry = new Country{Id = 4, Name = "" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Update(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Delete_IdExisting_ReturnsDeletedCountryWithSpecifiedId()
        {
            //Arrange
            int existingId = 12;
            Country expected = new Country { Id = existingId, Name = "Denmark" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Delete(existingId)).
                Returns(expected);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Country actual = countryService.Delete(existingId);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_IdNonExisting_ReturnsNull()
        {
            //Arrange
            int nonExistingId = 12;
            Country expected = null;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            countryRepository.Setup(repo => repo.Delete(nonExistingId)).
                Returns(expected);

            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Country actual = countryService.Delete(nonExistingId);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
