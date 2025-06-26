using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;

namespace SunAuto.Usps.Client;

public class Addresses(IHttpClientFactory httpClientFactory, IConfiguration configuration) :
    Factory(httpClientFactory, configuration)
{
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

        requesturl.Append($"{BaseUrl}/address?streetAddress={streetAddress}&state={state}&ZIPCode={zipCode}");
        requesturl.Append(Parameter("firm", firm));
        requesturl.Append(Parameter("secondaryAddress", secondaryAddress));
        requesturl.Append(Parameter("city", city));
        requesturl.Append(Parameter("urbanization", urbanization));
        requesturl.Append(Parameter("ZIPPlus4", zipPlus4));

        await AuthorizeAsync(cancellationToken);

        var check = await HttpClient.GetFromJsonAsync<StandardizedAddress>(requesturl.ToString(), cancellationToken);

        return check;
    }

    public async Task<CityStateResult?> GetCityAndStateAsync(string zipcode, CancellationToken cancellationToken = default)
    {
        var requesturl = $"{BaseUrl}/city-state?ZIPCode={zipcode}";

        await AuthorizeAsync(cancellationToken);

        var check = await HttpClient.GetFromJsonAsync<CityStateResult>(requesturl.ToString(), cancellationToken);

        return check;
    }
}
