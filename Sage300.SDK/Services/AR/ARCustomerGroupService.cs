using Sage300API.SDK.Core;
using Sage300API.SDK.Interfaces;
using Sage300API.SDK.Models.AR;

namespace Sage300API.SDK.Services.AR;

public class ARCustomerGroupService
    : IARCustomerGroupService
{
    private readonly Sage300Client _client;

    public ARCustomerGroupService(
        Sage300Client client)
    {
        _client = client;
    }

    public async Task<List<ARCustomerGroup>> GetAllAsync(
        ODataQueryOptions? query = null)
    {
        var url =
            _client.BuildEndpoint("AR/ARCustomerGroups") +
            (query?.ToQueryString() ?? "");

        var result =
            await _client.GetAsync<
                ODataResponse<ARCustomerGroup>>(url);

        return result?.Value ?? [];
    }

    public async Task<ARCustomerGroup?> GetByCodeAsync(
        string groupCode,
        IEnumerable<string>? select = null)
    {
        var query =
            select == null
                ? ""
                : $"?$select={string.Join(",", select)}";

        var url =
            _client.BuildEndpoint(
                $"AR/ARCustomerGroups('{groupCode}')")
            + query;

        var result =
            await _client.GetAsync<
                ODataResponse<ARCustomerGroup>>(url);

        return result?.Value.FirstOrDefault();
    }
}