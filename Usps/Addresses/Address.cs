using System.Text;

namespace SunAuto.Usps.Client.Addresses;

public class Address
{
    public string? StreetAddress { get; set; }
    public string? StreetAddressAbbreviation { get; set; }
    public string? SecondaryAddress { get; set; }
    public string? CityAbbreviation { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? ZipPlus4 { get; set; }
    public string? Urbanization { get; set; }
    public string? PropertyName { get; set; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        var requesturl = new StringBuilder();

        if (!String.IsNullOrWhiteSpace(Urbanization)) requesturl.AppendLine(Urbanization);
        requesturl.AppendLine(StreetAddress);
        if (!String.IsNullOrWhiteSpace(SecondaryAddress)) requesturl.AppendLine(SecondaryAddress);
        requesturl.Append($"{City} {State} {ZipCode}-{ZipPlus4}");

        return requesturl.ToString();
    }
}