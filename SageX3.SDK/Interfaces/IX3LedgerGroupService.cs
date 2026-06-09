using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3LedgerGroupService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3LedgerGroupDto dto,
        CancellationToken cancellationToken = default);
}
