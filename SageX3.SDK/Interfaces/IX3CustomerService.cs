using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3CustomerService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3CustomerDto customer,
        CancellationToken cancellationToken = default);
}
