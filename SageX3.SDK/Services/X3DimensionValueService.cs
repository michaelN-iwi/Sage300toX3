using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3DimensionValueService
    : IX3DimensionValueService
{
    private const string PublicName = "S300CCE";
    private readonly SageX3WebServiceClient _client;

    public X3DimensionValueService(SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3DimensionValueDto dto,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            dto.ToX3Xml(),
            cancellationToken);
    }
}
