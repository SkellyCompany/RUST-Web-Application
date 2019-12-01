using Moq;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Core.ApplicationService.Services;
using RUSTWebApplication.Core.DomainService;
using Xunit;
using RUSTWebApplication.Core.Entity.Order;

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

		}

		[Fact]
		public void Create_NameNullOrEmpty_ThrowsArgumentNullException()
		{

		}

		[Fact]
		public void Create_NameLowerCased_ThrowsArgumentException()
		{

		}
	}
}
