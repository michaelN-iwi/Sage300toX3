namespace Sage300API.SDK.Core;

public class ODataQueryOptions
{
    public string? Filter { get; set; }

    public IEnumerable<string>? Select { get; set; }

    public int? Top { get; set; }

    public int? Skip { get; set; }

    public bool? Count { get; set; }

    public string ToQueryString()
    {
        var parameters = new List<string>();

        if (!string.IsNullOrWhiteSpace(Filter))
            parameters.Add($"$filter={Uri.EscapeDataString(Filter)}");

        if (Select?.Any() == true)
            parameters.Add($"$select={string.Join(",", Select)}");

        if (Top.HasValue)
            parameters.Add($"$top={Top}");

        if (Skip.HasValue)
            parameters.Add($"$skip={Skip}");

        if (Count.HasValue)
            parameters.Add($"$count={Count.Value.ToString().ToLower()}");

        return parameters.Count == 0
            ? string.Empty
            : "?" + string.Join("&", parameters);
    }
}