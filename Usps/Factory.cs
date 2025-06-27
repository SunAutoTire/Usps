using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;

namespace SunAuto.Usps.Client;

public abstract class Factory(IHttpClientFactory httpClientFactory, IConfiguration configuration) :
    IDisposable
{
    const string TokenUrl = "https://api.usps.com/oauth2/v3/token";
    const string RevokeUrl = "https://api.usps.com/oauth2/v3/revoke";
    readonly string ClientId = configuration?["Usps:ClientId"] ?? throw new ArgumentException(Startup.ExceptionMessage);
    readonly string ClientSecret = configuration?["Usps:ClientSecret"] ?? throw new ArgumentException(Startup.ExceptionMessage);

    protected string BaseUrl { get; } = configuration?["Usps:BaseUrl"] ?? throw new ArgumentException(Startup.ExceptionMessage);

    static protected TokenResult? Authorization { get; private set; }

    protected HttpClient HttpClient { get; } = httpClientFactory.CreateClient();

    async Task AuthorizeAsync(CancellationToken cancellationToken = default)
    {
        if (Authorization == null || DateTime.UtcNow > Expiration)
        {
            var body = new List<KeyValuePair<string, string>>
            {
                new("client_id", ClientId),
                new("client_secret", ClientSecret),
                new("grant_type", "client_credentials")
            };

            using var client = httpClientFactory.CreateClient("AuthorizationClient");

            using var req = new HttpRequestMessage(HttpMethod.Post, TokenUrl)
            {
                Content = new FormUrlEncodedContent(body)
            };

            using var result = await client.SendAsync(req, cancellationToken);
            using var check = await result.Content.ReadAsStreamAsync(cancellationToken);

            Authorization = JsonSerializer.Deserialize<TokenResult>(check);

            if (Authorization?.Status != "approved")
                throw new InvalidOperationException("Authorization not approved.");

            //var issuedat = DateTimeOffset.FromUnixTimeSeconds(Authorization.IssuedAt).UtcDateTime;

            var issuedtimestamp = DateTime.UtcNow;

            Expiration = issuedtimestamp + TimeSpan.FromSeconds(Authorization.ExpiresIn - 1);
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Authorization?.AccessToken);
        }
    }

    async Task RevokeAsync(CancellationToken cancellationToken = default)
    {
        if (Authorization != null)
        {
            var body = new List<KeyValuePair<string, string>>
            {
                new("token", Authorization.AccessToken),
                new("token_type_hint", "access_token")
            };

            using var client = httpClientFactory.CreateClient("configured-inner-handler");

            using var req = new HttpRequestMessage(HttpMethod.Post, RevokeUrl)
            {
                Content = new FormUrlEncodedContent(body)
            };

            using var result = await client.SendAsync(req, cancellationToken);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
                //    throw new InvalidOperationException("Access token could not be revoked.");
                //else
                Authorization = null;
        }
    }

    protected static string Parameter(string key, string? value) => String.IsNullOrWhiteSpace(value)
        ? String.Empty
        : $"&{key}={value}";

    public async Task<T?> GetDataAsync<T>(string requesturl, CancellationToken cancellationToken = default) where T : class
    {
        await AuthorizeAsync(cancellationToken);

        var message = await HttpClient.GetAsync(requesturl.ToString(), cancellationToken);

        switch (message.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                return await message.Content.ReadFromJsonAsync<T>(cancellationToken);
            case System.Net.HttpStatusCode.BadRequest:
            default:
                var response = await message.Content.ReadFromJsonAsync<ErrorResponse>(cancellationToken);
                var ex = new ArgumentException("Invalid request parameters.");
                ex.Data.Add("ErrorResponse", response);
                throw ex;
        }
    }


    #region Disposable

    static DateTime Expiration;
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                RevokeAsync().GetAwaiter().GetResult();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~Factory()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
