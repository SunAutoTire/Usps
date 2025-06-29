using System.Text;

namespace SunAuto.Usps.Client.Addresses;

public class Query
{
    public string? Firm { get; set; }
    public string StreetAddress { get; set; } = null!;
    public string? SecondaryAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string Urbanization { get; set; } = null!;
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

    public override string? ToString() => base.ToString();

    /// <summary>
    /// Create query parameter list.
    /// </summary>
    /// <returns>String in the form of a URL parameter list.</returns>
    public string ToQuery()
    {
        var requesturl = new StringBuilder();

        requesturl.Append($"streetAddress={StreetAddress}&state={State}&ZIPCode={ZipCode}");
        // requesturl.Append("firm".Parameter( Firm));
        requesturl.Append("secondaryAddress".Parameter(SecondaryAddress));
        requesturl.Append("city".Parameter(City));
        // requesturl.Append("urbanization".Parameter( Urbanization));
        requesturl.Append("ZIPPlus4".Parameter(ZipPlus4));

        return requesturl.ToString();
    }
}