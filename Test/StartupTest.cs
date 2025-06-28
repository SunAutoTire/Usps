using System.Text;

namespace SunAuto.Usps.Client.Test;

public class StartupTest
{
    [Fact(DisplayName = "Configuration exception message")]
    public void Test1()
    {
        var check = Usps.Client.Startup.ExceptionMessage;

        Assert.Equals(GetErrorMessage(), check);
    }

    string GetErrorMessage()
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