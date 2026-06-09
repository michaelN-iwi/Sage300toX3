using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3DimensionValueService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3DimensionValueDto dto,
        CancellationToken cancellationToken = default);
}
