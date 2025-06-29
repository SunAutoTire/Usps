using System.Text;

namespace SunAuto.Usps.Client.Addresses;

/// <summary>
/// Standardizes street addresses including city and street abbreviations as well as providing missing information such as ZIP Code™ and ZIP + 4®.


/// </summary>
/// <remarks>
/// Must specify a street address, a state, and either a city or a ZIP Code™.
/// </remarks>
public class Query
{
    /// <summary>
    /// Firm/business corresponding to the address.
    /// </summary>
    /// <remarks>
    /// string [ 0 .. 50 ] characters
    ///</remarks>
    public string? Firm { get; set; }

    /// <summary>
    /// The number of a building along with the name of the road or street on which it is located.
    /// </summary>
    public string StreetAddress { get; set; } = null!;

    /// <summary>
    /// The secondary unit designator, such as apartment(APT) or suite(STE) number, defining the exact location of the address within a building. For more information please see Postal Explorer.
    /// </summary>
    public string? SecondaryAddress { get; set; }

    /// <summary>
    /// This is the city name of the address.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// The two-character state code of the address.
    /// </summary>
    /// <remarks>
    /// string = 2 characters, pattern: <code>^(AA|AE|AL|AK|AP|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MP|MT|NE|NV|NH|NJ|NM|NY|NC|ND|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)</code>
    ///</remarks>
    public string State { get; set; } = null!;

    /// <summary>
    /// This is the urbanization code relevant only for Puerto Rico addresses.
    /// </summary>
    public string? Urbanization { get; set; } = null!;

    /// <summary>
    /// This is the 5-digit ZIP code.
    /// </summary>
    /// <remarks>
    /// string = 2 characters, pattern: <code>^\d{5}$</code>
    ///</remarks>
    public string? ZipCode { get; set; }

    /// <summary>
    /// This is the 4-digit component of the ZIP+4 code. Using the correct ZIP+4 reduces the number of times your mail is handled and can decrease the chance of a misdelivery or error.
    /// </summary>
    /// <remarks>
    /// string = 2 characters, pattern: <code>^\d{4}$</code>
    ///</remarks>
    public string? ZipPlus4 { get; set; }

    public override bool Equals(object? obj) => throw new NotImplementedException();
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>
    /// Human readable expression.
    /// </summary>
    public override string? ToString()
    {
        var requesturl = new StringBuilder();

        if (!String.IsNullOrWhiteSpace(Firm)) requesturl.AppendLine(Firm);
        if (!String.IsNullOrWhiteSpace(Urbanization)) requesturl.AppendLine(Urbanization);
        requesturl.AppendLine(StreetAddress);
        if (!String.IsNullOrWhiteSpace(StreetAddress)) requesturl.AppendLine($"{StreetAddress}&state={State}&ZIPCode={ZipCode}");
        requesturl.AppendLine($"{City} {State} {ZipCode}-{ZipPlus4}");
        requesturl.AppendLine($"{StreetAddress}&state={State}&ZIPCode={ZipCode}");

        return requesturl.ToString();
    }

    /// <summary>
    /// Create query parameter list.
    /// </summary>
    /// <returns>String in the form of a URL parameter list.</returns>
    public string ToQuery()
    {
        var requesturl = new StringBuilder();

        requesturl.Append($"streetAddress={StreetAddress}&state={State}&ZIPCode={ZipCode}");
        requesturl.Append("firm".Parameter(Firm));
        requesturl.Append("secondaryAddress".Parameter(SecondaryAddress));
        requesturl.Append("city".Parameter(City));
        requesturl.Append("urbanization".Parameter(Urbanization));
        requesturl.Append("ZIPPlus4".Parameter(ZipPlus4));

        return requesturl.ToString();
    }
}