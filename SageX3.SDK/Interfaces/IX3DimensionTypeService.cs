using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3DimensionTypeService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3DimensionTypeDto dto,
        CancellationToken cancellationToken = default);
}
