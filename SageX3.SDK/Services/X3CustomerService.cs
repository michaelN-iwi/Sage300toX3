using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3CustomerService
    : IX3CustomerService
{
    private const string PublicName = "S300BPC";
    private readonly SageX3WebServiceClient _client;
    private readonly int _optionalFieldCapacity;

    public X3CustomerService(
        SageX3WebServiceClient client,
        int optionalFieldCapacity = 9)
    {
        _client = client;
        _optionalFieldCapacity = optionalFieldCapacity;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3CustomerDto customer,
        CancellationToken cancellationToken = default)
    {
        var xml = customer.ToX3Xml(_optionalFieldCapacity);

        return _client.SaveAsync(
            PublicName,
            xml,
            cancellationToken);
    }
}
