using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3OptionalFieldService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3OptionalFieldDto optionalField,
        CancellationToken cancellationToken = default);
}
