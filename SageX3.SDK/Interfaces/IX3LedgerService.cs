using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3LedgerService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3LedgerDto dto,
        CancellationToken cancellationToken = default);
}
