using System.Text.Json.Serialization;

namespace SunAuto.Usps.Client;

public class Result
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;
    
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = null!;
    
    [JsonPropertyName("issued_at")]
    public long IssuedAt { get; set; } 
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; } 
    
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;
    
    [JsonPropertyName("scope")]
    public string Scopes { get; set; } = null!;
    
    [JsonPropertyName("issuer")]
    public string Issuer { get; set; } = null!;
    
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = null!;
    
    [JsonPropertyName("application_name")]
    public string ApplicationName { get; set; } = null!;
    
    [JsonPropertyName("api_products")]
    public string ApiProducts { get; set; } = null!;
  
    [JsonPropertyName("public_key")]
    public string PublicKey { get; set; } = null!;
}
