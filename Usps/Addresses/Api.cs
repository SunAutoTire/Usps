using Microsoft.Extensions.Configuration;
using System.Text;

namespace SunAuto.Usps.Client.Addresses;

/// <summary>
/// The Addresses API validates and corrects address information to improve package delivery service and pricing. This suite of APIs provides different utilities for addressing components. The ZIP Code™ lookup finds valid ZIP Code™(s) for a City and State. The City/State lookup provides the valid cities and states for a provided ZIP Code™. The Address Standardization API validates and standardizes USPS® domestic addresses, city and state names, and ZIP Code™ in accordance with USPS® addressing standards. The USPS® address standard includes the ZIP + 4®, signifying a USPS® delivery point, given a street address, a city and a state.
/// </summary>
/// <param name="httpClientFactory">DI HTTP Client Factory</param>
/// <param name="configuration">DI Configuration</param>
public class Api(IHttpClientFactory httpClientFactory, IConfiguration configuration) :
    Factory(httpClientFactory, configuration)
{
    const string BasePath = "addresses/v3";

    /// <summary>
    /// Standardizes street addresses including city and street abbreviations as well as providing missing information such as ZIP Code™ and ZIP + 4®.
    /// </summary>
    /// <param name="streetAddress">The number of a building along with the name of the road or street on which it is located. (required)</param>
    /// <param name="state">The two-character state code of the address. (pattern: <code>^(AA|AE|AL|AK|AP|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MP|MT|NE|NV|NH|NJ|NM|NY|NC|ND|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)$</code></param>
    /// <param name="zipCode">This is the 5-digit ZIP code. (pattern: <code>^\d{5}$</code></param>
    /// <param name="firm">Firm/business corresponding to the address. (string[0..50] characters)</param>
    /// <param name="secondaryAddress">The secondary unit designator, such as apartment(APT) or suite(STE) number, defining the exact location of the address within a building. For more information please see Postal Explorer.</param>
    /// <param name="city">This is the city name of the address.</param>
    /// <param name="urbanization">This is the urbanization code relevant only for Puerto Rico addresses.</param>
    /// <param name="zipPlus4">This is the 4-digit component of the ZIP+4 code. Using the correct ZIP+4 reduces the number of times your mail is handled and can decrease the chance of a misdelivery or error. (pattern: <code>^\d{4}$</code></param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. Defaults to <see langword="default"/> if not provided.</param>
    /// <returns>Standardized street address</returns>
    public async Task<StandardizedAddress?> GetStandardizedAddressAsync(string streetAddress,
        string state,
        string zipCode,
        string? firm = null,
        string? secondaryAddress = null,
        string? city = null, string?
        urbanization = null,
        string? zipPlus4 = null,
        CancellationToken cancellationToken = default)
    {
        var requesturl = new StringBuilder();

        requesturl.Append($"{BaseUrl}/{BasePath}/address?streetAddress={streetAddress}&state={state}&ZIPCode={zipCode}");
        requesturl.Append("firm".Parameter(firm));
        requesturl.Append("secondaryAddress".Parameter(secondaryAddress));
        requesturl.Append("city".Parameter(city));
        requesturl.Append("urbanization".Parameter(urbanization));
        requesturl.Append("ZIPPlus4".Parameter(zipPlus4));

        return await GetDataAsync<StandardizedAddress>(requesturl.ToString(), cancellationToken);
    }

    /// <summary>
    /// Standardizes street addresses including city and street abbreviations as well as providing missing information such as ZIP Code™ and ZIP + 4®.
    /// </summary>
    /// <remarks>This method sends a request to an external service to standardize the address based on the
    /// query. Ensure that the query is properly formatted before calling this method.</remarks>
    /// <param name="query">The query containing address information to be standardized. Cannot be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. Defaults to <see langword="default"/> if not provided.</param>
    /// <returns>A <see cref="StandardizedAddress"/> object representing the standardized address, or <see langword="null"/> if
    /// the address could not be standardized.</returns>
    public async Task<StandardizedAddress?> GetStandardizedAddressAsync(Query query, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/{BasePath}/address?{query.ToQuery()}";

        return await GetDataAsync<StandardizedAddress>(requesturl.ToString(), cancellationToken);
    }

    /// <summary>
    /// Retrieves the city and state information for the specified ZIP code.
    /// </summary>
    /// <remarks>This method performs an asynchronous HTTP request to retrieve the city and state information.
    /// Ensure that the provided ZIP code is valid and formatted correctly to avoid errors.</remarks>
    /// <param name="zipcode">The ZIP code for which to retrieve city and state information. Must be a valid ZIP code.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. Defaults to <see langword="default"/> if not provided.</param>
    /// <returns>A <see cref="CityStateResult"/> object containing the city and state information for the specified ZIP code,  or
    /// <see langword="null"/> if the information could not be retrieved.</returns>
    public async Task<CityStateResult?> GetCityAndStateAsync(string zipcode, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/{BasePath}/city-state?ZIPCode={zipcode}";

        return await GetDataAsync<CityStateResult>(requesturl.ToString(), cancellationToken);
    }

    public async Task<ZipCode?> GetZipCodeAsync(string streetAddress,
        string state,
        string zipCode,
        string? firm = null,
        string? secondaryAddress = null,
        string? city = null, string?
        urbanization = null,
        string? zipPlus4 = null,
        CancellationToken cancellationToken = default)
    {
        var requesturl = new StringBuilder();

        requesturl.Append($"{BaseUrl}/{BasePath}/zipcode?streetAddress={streetAddress}&state={state}&ZIPCode={zipCode}");
        requesturl.Append("firm".Parameter(firm));
        requesturl.Append("secondaryAddress".Parameter(secondaryAddress));
        requesturl.Append("city".Parameter(city));
        requesturl.Append("urbanization".Parameter(urbanization));
        requesturl.Append("ZIPPlus4".Parameter(zipPlus4));

        return await GetDataAsync<ZipCode>(requesturl.ToString(), cancellationToken);
    }

    /// <summary>
    /// Retrieves the standardized address, including the ZIP code, based on the specified query.
    /// </summary>
    /// <remarks>This method sends an asynchronous request to the configured API endpoint to retrieve the ZIP
    /// code based on the provided query parameters. Ensure that the query is properly formatted using <see
    /// cref="Query.ToQuery"/> before calling this method.</remarks>
    /// <param name="query">The query containing the parameters used to search for the ZIP code. Must not be null.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests. Optional; defaults to <see langword="default"/>.</param>
    /// <returns>A <see cref="StandardizedAddress"/> object containing the standardized address and ZIP code, or <see
    /// langword="null"/> if no matching address is found.</returns>
    public async Task<ZipCode?> GetZipCodeAsync(Query query, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/{BasePath}/zipcode?{query.ToQuery()}";

        return await GetDataAsync<ZipCode>(requesturl.ToString(), cancellationToken);
    }
}
