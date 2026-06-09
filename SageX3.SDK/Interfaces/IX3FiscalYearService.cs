using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3FiscalYearService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3FiscalYearDto dto,
        CancellationToken cancellationToken = default);
}
