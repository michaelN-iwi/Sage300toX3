namespace Sage300API.SDK.Core;

public sealed class Sage300Options
{
    public required string BaseUrl { get; init; }

    public required string ApiVersion { get; init; }

    public required string Tenant { get; init; }

    public required string Company { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }
}