namespace SunAuto.Usps.Client
{
    public class ErrorDetail
    {
        public string Title { get; set; } = null!;
        public string Detail{ get; set; } = null!;
        public string? Source { get; set; } = null!;
    }
}