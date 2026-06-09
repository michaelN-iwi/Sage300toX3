using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3FiscalYearService
    : IX3FiscalYearService
{
    private const string PublicName = "S300FIY";
    private readonly SageX3WebServiceClient _client;

    public X3FiscalYearService(SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3FiscalYearDto dto,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            dto.ToX3Xml(),
            cancellationToken);
    }
}
