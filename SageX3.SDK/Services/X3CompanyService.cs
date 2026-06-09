using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3CompanyService
    : IX3CompanyService
{
    private const string PublicName = "S300CPY";
    private readonly SageX3WebServiceClient _client;

    public X3CompanyService(SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3CompanyDto dto,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            dto.ToX3Xml(),
            cancellationToken);
    }
}
