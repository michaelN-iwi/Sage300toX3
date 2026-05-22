using SageX3.SDK.Core;
using SageX3.SDK.Interfaces;
using SageX3.SDK.Models;

namespace SageX3.SDK.Services;

public sealed class X3CustomerCategoryService
    : IX3CustomerCategoryService
{
    private const string PublicName = "S300CRMCAT";
    private readonly SageX3WebServiceClient _client;

    public X3CustomerCategoryService(
        SageX3WebServiceClient client)
    {
        _client = client;
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        X3CustomerCategoryDto category,
        CancellationToken cancellationToken = default)
    {
        return _client.SaveAsync(
            PublicName,
            category.ToX3Xml(),
            cancellationToken);
    }
}
