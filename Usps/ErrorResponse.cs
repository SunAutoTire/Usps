namespace SunAuto.Usps.Client;

public class ErrorResponse
{
    public string ApiVersion{ get; set; } = null!;
    public Error Error { get; set; } = null!;
}
