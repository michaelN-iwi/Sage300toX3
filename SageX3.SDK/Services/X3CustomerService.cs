using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3CustomerService
    : IX3CustomerService
{
    private const string PublicName = "S300CRM";
    private readonly SageX3WebServiceClient _client;

    public X3CustomerService(
        SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3CustomerDto customer,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            customer.ToX3Xml(),
            cancellationToken);
    }
}
