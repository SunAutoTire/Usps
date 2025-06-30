namespace SunAuto.Usps.Client.Addresses;

public class StandardizedAddress: ZipCode
{
    public AdditionalInfo?  AdditionalInfo{ get; set; }
    public IEnumerable<CodeTextPair>? Corrections { get; set; }
    public IEnumerable<CodeTextPair>? Matches { get; set; }
}