namespace SunAuto.Usps.Client.Addresses;

public class StandardizedAddress
{
    public string? Firm { get; set; }
    public Address? Address { get; set; }
    public AdditionalInfo?  AdditionalInfo{ get; set; }
    public IEnumerable<CodeTextPair>? Corrections { get; set; }
    public IEnumerable<CodeTextPair>? Matches { get; set; }
}