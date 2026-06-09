using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3PeriodService
    : IX3PeriodService
{
    private const string PublicName = "S300PER";
    private readonly SageX3WebServiceClient _client;

    public X3PeriodService(SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3PeriodDto dto,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            dto.ToX3Xml(),
            cancellationToken);
    }
}
