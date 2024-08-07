using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Add country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest"></param>
        /// <returns>Return country object after adding it with newly generated country id</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
        /// <summary>
        /// Return all countries from the list
        /// </summary>
        /// <returns>All countries from the list as List of CountryResponse</returns>
        List<CountryResponse> GetAllCountries();
        /// <summary>
        /// Return a country object based on the given country id
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns>Matching country as CountryResponse object</returns>
        CountryResponse? GetCountryByCountryID(Guid? countryID);

    }
}
