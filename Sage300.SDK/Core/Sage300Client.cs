using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Sage300API.SDK.Core;

public sealed class Sage300Client
{
    private readonly HttpClient _httpClient;
    private readonly Sage300Options _options;

    private readonly JsonSerializerOptions _jsonOptions =
        new()
        {
            PropertyNameCaseInsensitive = true
        };

    public Sage300Client(
        HttpClient httpClient,
        Sage300Options options)
    {
        _httpClient = httpClient;
        _options = options;

        var auth =
            Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    $"{options.Username}:{options.Password}"));

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", auth);
    }

    public string BuildEndpoint(string resource)
    {
        return
            $"{_options.BaseUrl}/v{_options.ApiVersion}/" +
            $"{_options.Tenant}/" +
            $"{_options.Company}/" +
            resource;
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(
            json,
            _jsonOptions);
    }
}