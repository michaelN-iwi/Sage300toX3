using Sage300API.SDK.Models.AR;
using Sage300API.SDK.Core;

namespace Sage300API.SDK.Interfaces;

public interface IARCustomerGroupService
{
    Task<List<ARCustomerGroup>> GetAllAsync(
        ODataQueryOptions? query = null);

    Task<ARCustomerGroup?> GetByCodeAsync(
        string groupCode,
        IEnumerable<string>? select = null);
}