using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3CustomerCategoryService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3CustomerCategoryDto category,
        CancellationToken cancellationToken = default);
}
