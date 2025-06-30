using Microsoft.Extensions.Configuration;
using System.Text;

namespace SunAuto.Usps.Client.Addresses;

public class Api(IHttpClientFactory httpClientFactory, IConfiguration configuration) :
    Factory(httpClientFactory, configuration)
{
    const string BasePath = "addresses/v3";

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

    public async Task<StandardizedAddress?> GetStandardizedAddressAsync(Query query, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/{BasePath}/address?{query.ToQuery()}";

        return await GetDataAsync<StandardizedAddress>(requesturl.ToString(), cancellationToken);
    }

    public async Task<CityStateResult?> GetCityAndStateAsync(string zipcode, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/{BasePath}/city-state?ZIPCode={zipcode}";

        return await GetDataAsync<CityStateResult>(requesturl.ToString(), cancellationToken);
    }

    public async Task<StandardizedAddress?> GetZipCodeAsync(string streetAddress,
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

        return await GetDataAsync<StandardizedAddress>(requesturl.ToString(), cancellationToken);
    }

    public async Task<StandardizedAddress?> GetZipCodeAsync(Query query, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/{BasePath}/zipcode?{query.ToQuery()}";

        return await GetDataAsync<StandardizedAddress>(requesturl.ToString(), cancellationToken);
    }
}
