using SunAuto.Usps.Client.Addresses;

namespace SunAuto.Usps.Client.Test;

public class QueryTest
{
    [Theory(DisplayName = "ToQuery() Success")]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", "1234", ToQuerySuccess1)]
    [InlineData(null, "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", "1234", ToQuerySuccess2)]
    [InlineData("Firm", "1122 Mocking Bird Lane", null, "Muensterville", "CA", "Urbanization", "12345", "1234", ToQuerySuccess3)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", null, "CA", "Urbanization", "12345", "1234", ToQuerySuccess4)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", null, "12345", "1234", ToQuerySuccess5)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", null, "1234", ToQuerySuccess6)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", null, ToQuerySuccess7)]
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

        Assert.Equal(expected, check.ToQuery());
    }

    const string ToQuerySuccess1 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d12345%26firm%3dFirm%26secondaryAddress%3dGrandpa%27s+Lair%26city%3dMuensterville%26urbanization%3dUrbanization%26ZIPPlus4%3d1234";
    const string ToQuerySuccess2 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d12345%26secondaryAddress%3dGrandpa%27s+Lair%26city%3dMuensterville%26urbanization%3dUrbanization%26ZIPPlus4%3d1234";
    const string ToQuerySuccess3 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d12345%26firm%3dFirm%26city%3dMuensterville%26urbanization%3dUrbanization%26ZIPPlus4%3d1234";
    const string ToQuerySuccess4 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d12345%26firm%3dFirm%26secondaryAddress%3dGrandpa%27s+Lair%26urbanization%3dUrbanization%26ZIPPlus4%3d1234";
    const string ToQuerySuccess5 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d12345%26firm%3dFirm%26secondaryAddress%3dGrandpa%27s+Lair%26city%3dMuensterville%26ZIPPlus4%3d1234";
    const string ToQuerySuccess6 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d%26firm%3dFirm%26secondaryAddress%3dGrandpa%27s+Lair%26city%3dMuensterville%26urbanization%3dUrbanization%26ZIPPlus4%3d1234";
    const string ToQuerySuccess7 = "streetAddress%3d1122+Mocking+Bird+Lane%26state%3dCA%26ZIPCode%3d12345%26firm%3dFirm%26secondaryAddress%3dGrandpa%27s+Lair%26city%3dMuensterville%26urbanization%3dUrbanization";

    [Theory(DisplayName = "ToString() Full Success")]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", "1234", ToStringSuccess1)]
    [InlineData(null, "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", "1234", ToStringSuccess2)]
    [InlineData("Firm", "1122 Mocking Bird Lane", null, "Muensterville", "CA", "Urbanization", "12345", "1234", ToStringSuccess3)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", null, "CA", "Urbanization", "12345", "1234", ToStringSuccess4)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", null, "12345", "1234", ToStringSuccess5)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", null, "1234", ToStringSuccess6)]
    [InlineData("Firm", "1122 Mocking Bird Lane", "Grandpa's Lair", "Muensterville", "CA", "Urbanization", "12345", null, ToStringSuccess7)]
    public void Test2(string? firm,
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

    const string ToStringSuccess1 = "Firm\r\nUrbanization\r\n1122 Mocking Bird Lane\r\nGrandpa's Lair\r\nMuensterville CA 12345-1234";
    const string ToStringSuccess2 = "Urbanization\r\n1122 Mocking Bird Lane\r\nGrandpa's Lair\r\nMuensterville CA 12345-1234";
    const string ToStringSuccess3 = "Firm\r\nUrbanization\r\n1122 Mocking Bird Lane\r\nMuensterville CA 12345-1234";
    const string ToStringSuccess4 = "Firm\r\nUrbanization\r\n1122 Mocking Bird Lane\r\nGrandpa's Lair\r\n CA 12345-1234";
    const string ToStringSuccess5 = "Firm\r\n1122 Mocking Bird Lane\r\nGrandpa's Lair\r\nMuensterville CA 12345-1234";
    const string ToStringSuccess6 = "Firm\r\nUrbanization\r\n1122 Mocking Bird Lane\r\nGrandpa's Lair\r\nMuensterville CA -1234";
    const string ToStringSuccess7 = "Firm\r\nUrbanization\r\n1122 Mocking Bird Lane\r\nGrandpa's Lair\r\nMuensterville CA 12345-";
}
