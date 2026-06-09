using Sage300API.SDK.Core;
using Sage300API.SDK.Interfaces;
using Sage300API.SDK.Models.AR;

namespace Sage300API.SDK.Services.AR;

public class ARCustomerService
    : IARCustomerService
{
    private readonly Sage300Client _client;

    public ARCustomerService(
        Sage300Client client)
    {
        _client = client;
    }

    public async Task<List<ARCustomer>> GetAllAsync(
        ODataQueryOptions? query = null)
    {
        var url =
            _client.BuildEndpoint("AR/ARCustomers") +
            (query?.ToQueryString() ?? "");

        var result =
            await _client.GetAsync<
                ODataResponse<ARCustomer>>(url);

        return result?.Value ?? [];
    }

    public async Task<ARCustomer?> GetByNumberAsync(
        string customerNumber,
        IEnumerable<string>? select = null)
    {
        var query =
            select == null
                ? ""
                : $"?$select={string.Join(",", select)}";

        var url =
            _client.BuildEndpoint(
                $"AR/ARCustomers('{customerNumber}')")
            + query;

        var result =
            await _client.GetAsync<
                ODataResponse<ARCustomer>>(url);

        return result?.Value.FirstOrDefault();
    }
}