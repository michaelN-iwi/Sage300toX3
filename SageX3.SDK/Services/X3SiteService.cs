using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3SiteService
    : IX3SiteService
{
    private const string PublicName = "S300FCY";
    private readonly SageX3WebServiceClient _client;

    public X3SiteService(SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3SiteDto dto,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            dto.ToX3Xml(),
            cancellationToken);
    }
}
