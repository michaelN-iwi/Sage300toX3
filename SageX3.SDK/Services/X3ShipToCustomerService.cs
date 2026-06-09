using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3ShipToCustomerService
    : IX3ShipToCustomerService
{
    private const string PublicName = "S300BPD";
    private readonly SageX3WebServiceClient _client;

    public X3ShipToCustomerService(
        SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3ShipToCustomerDto shipToCustomer,
        CancellationToken cancellationToken = default)
    {
        shipToCustomer.Validate();

        return _client.SaveAsync(
            PublicName,
            shipToCustomer.ToX3Xml(),
            cancellationToken);
    }
}
