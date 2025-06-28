using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace SunAuto.Usps.Client;

/// <summary>
/// Extension methods for configuring the USPS client services.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Adds the USPS client services to the service collection.
    /// </summary>
    /// <param name="services">Services collection</param>
    /// <param name="configuration">Entire configuration object</param>
    /// <returns>Services collection now containing necessary objects.</returns>
    /// <exception cref="ArgumentException">Base URL is not configured.</exception>
    public static IServiceCollection AddSatsUspsClient(this IServiceCollection services, IConfiguration configuration, string sectionName = "Usps")
    {
        services.AddHttpClient("AuthorizationClient", client =>
        {
            client.BaseAddress = new Uri(configuration[$"{sectionName}:BaseUrl"] ?? throw new ArgumentException("BaseUrl is not configured"));
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
        {
            UseCookies = false
        });

        services.AddScoped<Addresses>();

        return services;
    }

    /// <summary>
    /// A human-readable message to display when the configuration is not set up correctly.
    /// </summary>
    public static string ExceptionMessage
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
            output.AppendLine("or if using an Azure Function:");
            output.AppendLine();
            output.AppendLine("{");
            output.AppendLine("\"Usps:BaseUrl\": \"<USPS Base URL>\",");
            output.AppendLine("\"Usps:ClientSecret\": \"<USPS Issued Client Secret>\",");
            output.AppendLine("\"Usps:ClientId\": \"<USPS Issued Client ID>\"");
            output.AppendLine("}");

            return output.ToString();
        }
    }
}
