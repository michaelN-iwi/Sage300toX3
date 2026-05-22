namespace SageX3.SDK.Core;

public sealed class SageX3Options
{
    public string EndpointUrl { get; init; } = string.Empty;

    public string Username { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string Language { get; init; } = "ENG";

    public string PoolAlias { get; init; } = "S300";

    public string RequestConfig { get; init; } = string.Empty;

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(EndpointUrl))
        {
            throw new InvalidOperationException("SageX3:EndpointUrl is required.");
        }

        if (string.IsNullOrWhiteSpace(Username))
        {
            throw new InvalidOperationException("SageX3:Username is required.");
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            throw new InvalidOperationException("SageX3:Password is required.");
        }

        if (string.IsNullOrWhiteSpace(Language))
        {
            throw new InvalidOperationException("SageX3:Language is required.");
        }

        if (string.IsNullOrWhiteSpace(PoolAlias))
        {
            throw new InvalidOperationException("SageX3:PoolAlias is required.");
        }
    }
}
