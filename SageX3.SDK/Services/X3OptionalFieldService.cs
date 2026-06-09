using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3OptionalFieldService
    : IX3OptionalFieldService
{
    private const string PublicName = "S300OPTFIELD";
    private readonly SageX3WebServiceClient _client;

    public X3OptionalFieldService(
        SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3OptionalFieldDto optionalField,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            optionalField.ToX3Xml(),
            cancellationToken);
    }
}
