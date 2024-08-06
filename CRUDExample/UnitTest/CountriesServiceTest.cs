using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace UnitTest
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry
        // When CountryAddRequest is null => throw ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            // Arrange
            CountryAddRequest? request = null;
            //Assert 
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _countriesService.AddCountry(request);
            });
        }
        // When CountryName is null => throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null };
            //Assert 
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countriesService.AddCountry(request);
            });
        }
        // When CountryName is duplicate => throw ArgumentException
        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            // Arrange
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "Vietnam" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "Vietnam" };
            //Assert 
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }
        // When supply proper country name, it should insert the country to the existing list of countries
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Vietnam" };
            // Act
            CountryResponse response = _countriesService.AddCountry(request);
            List<CountryResponse> countriesFromGetAllCountries = _countriesService.GetAllCountries();
            //Assert 
            Assert.True(response.CountryID != Guid.Empty);
            Assert.Contains(response, countriesFromGetAllCountries); // => override by Equals at CountryReponse.cs

        }
        #endregion

        #region GetAllCountries
        [Fact]
        // The list of countries should be empty by default (before adding any countries)
        public void GetAllCountries_EmptyList()
        {
            // Acts
            List<CountryResponse> actualCountriesResponseList = _countriesService.GetAllCountries();

            // Assert
            Assert.Empty(actualCountriesResponseList);
        }
        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            // Arrage
            List<CountryAddRequest> requests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName = "Vietnam" },
                new CountryAddRequest() { CountryName = "Cuba" },
            };

            // Act
            List<CountryResponse> countriesListFromAddCountry = new List<CountryResponse>();
            foreach (CountryAddRequest request in requests)
            {
                countriesListFromAddCountry.Add(_countriesService.AddCountry(request));
            }

            List<CountryResponse> actualContryReponseList = _countriesService.GetAllCountries();

            // Asserts
            foreach (CountryResponse expectedCountry in countriesListFromAddCountry)
            {
                Assert.Contains(expectedCountry, actualContryReponseList);
            }
        }
        #endregion
    }
}
