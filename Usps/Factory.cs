using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace SunAuto.Usps.Client;

public abstract class Factory(IHttpClientFactory httpClientFactory, IConfiguration configuration)
{
    const string TokenUrl = "https://api.usps.com/oauth2/v3/token";
    readonly string ClientId = configuration?["Usps:ClientId"] ?? throw new ArgumentException(ExceptionMessage);
    readonly string ClientSecret = configuration?["Usps:ClientSecret"] ?? throw new ArgumentException(ExceptionMessage);

    protected string BaseUrl { get; } = configuration?["Usps:BaseUrl"] ?? throw new ArgumentException(ExceptionMessage);

    static protected Result? Authorization { get; private set; }

    protected HttpClient HttpClient { get; } = httpClientFactory.CreateClient();

    protected async Task AuthorizeAsync(CancellationToken cancellationToken = default)
    {
        if (Authorization == null)
        {
            var body = new List<KeyValuePair<string, string>>
            {
                new("client_id", ClientId),
                new("client_secret", ClientSecret),
                new("grant_type", "client_credentials")
            };

            using var client = httpClientFactory.CreateClient();

            using var req = new HttpRequestMessage(HttpMethod.Post, TokenUrl)
            {
                Content = new FormUrlEncodedContent(body)
            };

            using var result = await client.SendAsync(req, cancellationToken);

            var check = await result.Content.ReadAsStreamAsync(cancellationToken);

            Authorization = JsonSerializer.Deserialize<Result>(check);

            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Authorization?.AccessToken);
        }
    }

    static string ExceptionMessage
    {
        get
        {
            var output = new StringBuilder();

            output.AppendLine("Please check your configuration:");
            output.AppendLine();
            output.AppendLine("Configuration should look like (JSON):");
            output.AppendLine("\"Usps\": {");
            output.AppendLine("   \"BaseUrl\": \"<USPS Base URL>\",");
            output.AppendLine("   \"ClientSecret\": \"<USPS Issued Client Secret>\",");
            output.AppendLine("   \"ClientId\": \"<USPS Issued Client ID>\"");
            output.AppendLine("}");
            output.AppendLine();

            return output.ToString();
        }
    }
}
