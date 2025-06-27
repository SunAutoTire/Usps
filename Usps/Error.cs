using System.Text.Json.Serialization;

namespace SunAuto.Usps.Client
{
    public class Error
    {
        public string Code { get; set; } = null!;
        public string Message { get; set; } = null!;

        [JsonPropertyName("errors")]
        public IEnumerable<ErrorDetail>Details { get; set; } = null!;
    }
}