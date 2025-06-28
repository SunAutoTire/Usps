using System.Text;

namespace SunAuto.Usps.Client;

public class Address
{
    public string? StreetAddress { get; set; }
    public string? SecondaryAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? ZipPlus4 { get; set; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString() => base.ToString();

    public string ToQuery()
    {
        var requesturl = new StringBuilder();

        requesturl.Append($"addresses/v3/address?streetAddress={StreetAddress}&state={State}&ZIPCode={ZipCode}");
        // requesturl.Append("firm".Parameter( Firm));
        requesturl.Append("secondaryAddress".Parameter(SecondaryAddress));
        requesturl.Append("city".Parameter(City));
        // requesturl.Append("urbanization".Parameter( Urbanization));
        requesturl.Append("ZIPPlus4".Parameter(ZipPlus4));

        return requesturl.ToString();
    }
}