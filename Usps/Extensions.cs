namespace SunAuto.Usps.Client;

public static class Extensions
{
    public static string Parameter(this string key, string? value) => String.IsNullOrWhiteSpace(value)
        ? String.Empty
        : $"&{key}={value}";
}