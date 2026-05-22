using System.Text.Json.Serialization;

namespace Sage300API.SDK.Core;

public class ODataResponse<T>
{
    [JsonPropertyName("@odata.context")]
    public string? Context { get; set; }

    [JsonPropertyName("value")]
    public List<T> Value { get; set; } = [];
}