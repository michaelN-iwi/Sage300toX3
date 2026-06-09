using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3CompanyService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3CompanyDto dto,
        CancellationToken cancellationToken = default);
}
