using Sage300API.SDK.Models.AR;
using Sage300API.SDK.Core;

namespace Sage300API.SDK.Interfaces;

public interface IARCustomerService
{
    Task<List<ARCustomer>> GetAllAsync(
        ODataQueryOptions? query = null);

    Task<ARCustomer?> GetByNumberAsync(
        string customerNumber,
        IEnumerable<string>? select = null);
}