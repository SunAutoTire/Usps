using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace SunAuto.Usps.Client;

public static class Startup
{
    public static IServiceCollection AddUspsClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("AuthorizationClient", client =>
        {
            client.BaseAddress = new Uri(configuration["Usps:BaseUrl"] ?? throw new ArgumentException("BaseUrl is not configured"));
        })
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new HttpClientHandler()
            {
                UseCookies = false
            };
        });

        services.AddScoped<Addresses>();

        return services;
    }

    internal static string ExceptionMessage
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
