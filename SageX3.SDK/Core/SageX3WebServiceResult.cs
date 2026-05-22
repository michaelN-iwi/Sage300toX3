namespace SageX3.SDK.Core;

public sealed class SageX3WebServiceResult
{
    public bool Success { get; init; }

    public int? Status { get; init; }

    public string? TechnicalInfos { get; init; }

    public string? ResultXml { get; init; }

    public string RawResponse { get; init; } = string.Empty;

    public string? ErrorMessage { get; init; }
}
