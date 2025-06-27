namespace SunAuto.Usps.Client;

public class StandardizedAddress
{
    public Firm? Firm { get; set; }
    public Address? Address { get; set; }
    public AdditionalInfo? Corrections { get; set; }
    public Corrections? AdditionalInfo { get; set; }
    public Matches? Matches { get; set; }
}