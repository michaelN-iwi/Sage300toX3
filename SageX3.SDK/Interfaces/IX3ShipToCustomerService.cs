using SageX3.SDK.Core;
using SageX3.SDK.Models;

namespace SageX3.SDK.Interfaces;

public interface IX3ShipToCustomerService
{
    Task<SageX3WebServiceResult> SaveAsync(
        X3ShipToCustomerDto shipToCustomer,
        CancellationToken cancellationToken = default);
}
