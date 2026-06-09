using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3PeriodService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3PeriodDto dto,
        CancellationToken cancellationToken = default);
}
