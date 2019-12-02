using System;
using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Order;
using Xunit;

namespace RUSTWebApplication.UnitTests.Core
{
    public class CountryServiceTest
    {

        [Fact]
        public void Create_InputValid_ReturnsCreatedCountryWithId()
        {
            //Arange
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
        public void Create_IdSpecified_ThrowsArgumentException()
        {
            //Arange
            Country invalidCountry = new Country { Id = 1, Name = "Netherlands" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Create_CountryNull_ThrowsArgumentNullException()
        {
            //Arange
            Country invalidCountry = null;

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Create_NameNull_ThrowsArgumentException()
        {
            //Arange
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
            //Arange
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
            //Arange
            Country invalidCountry = new Country { Name = "netherlands" };

            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            ICountryService countryService = new CountryService(countryRepository.Object);

            //Act
            Action actual = () => countryService.Create(invalidCountry);

            //Assert
            Assert.Throws<ArgumentException>(actual);
        }
    }
}
