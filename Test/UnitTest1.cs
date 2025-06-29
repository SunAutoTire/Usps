using SunAuto.Usps.Client.Addresses;

namespace SunAuto.Usps.Client.Test;

public class QueryTest
{
    [Theory(DisplayName = "ToString() Full Success")]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", "1234", ToStringFullSuccess)]
    public void Test1(string? firm,
    string streetAddress,
    string? secondaryAddress,
    string? city,
    string state,
    string? urbanization,
    string? zipCode,
    string? zipPlus4,
    string? expected)
    {
        var check = new Query
        {
            City = city,
            Firm = firm,
            SecondaryAddress = secondaryAddress,
            State = state,
            StreetAddress = streetAddress,
            Urbanization = urbanization,
            ZipCode = zipCode,
            ZipPlus4 = zipPlus4
        };

        Assert.Equal(expected, check.ToString());
    }

    const string ToStringFullSuccess = "Firm"
    + Environment.NewLine + "Urbanization"
    + Environment.NewLine + "1122 Mocking Bird Lane"
    + Environment.NewLine + "Grandpa's Lair"
    + Environment.NewLine + "Muensterville CA 12345-1234";
}
