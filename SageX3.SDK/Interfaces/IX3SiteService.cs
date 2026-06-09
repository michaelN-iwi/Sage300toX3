using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3SiteService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3SiteDto dto,
        CancellationToken cancellationToken = default);
}
