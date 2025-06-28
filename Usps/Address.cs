namespace SunAuto.Usps.Client;

/// <summary>
/// Address information returned when finding a standardized address.
/// </summary>
/// <remarks>
/// This is transposed to query parameters
public class Address
{
    /// <summary>
    /// Firm/business corresponding to the address.
    /// </summary>
    public string? Firm { get; set; }

    /// <summary>
    /// The number of a building along with the name of the road or street on which it is located.
    /// </summary>
    public string? StreetAddress { get; set; }

    /// <summary>
    /// The secondary unit designator, such as apartment(APT) or suite(STE) number, defining the exact location of the address within a building.
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
    /// pattern: <code>^\\d{5}$</code>
    /// </remarks>
    public string? Urbanization { get; set; }

    /// <summary>
    /// This is the urbanization code relevant only for Puerto Rico addresses.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// The two-character state code of the address.
    /// </summary>
    /// <remarks>
    /// pattern: <code>^\\d{5}$</code>
    /// </remarks>
    public string? ZipCode { get; set; }

    /// <summary>
    /// This is the 4-digit component of the ZIP+4 code.
    /// </summary>
    /// <remarks>
    ///  Using the correct ZIP+4 reduces the number of times your mail is handled and can decrease the chance of a misdelivery or error.
    /// pattern: <code>^\\d{4}$</code>
    /// </remarks>
    public string? ZipPlus4 { get; set; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}