using Migration.Core.Options;

namespace Migration.Core.Transformation;

public sealed class ValueTransformer
{
    private readonly MigrationMappingOptions _mappings;
    private readonly X3DefaultValuesOptions _defaults;

    public ValueTransformer(
        MigrationMappingOptions mappings,
        X3DefaultValuesOptions defaults)
    {
        _mappings = mappings;
        _defaults = defaults;
    }

    public string Country(string? sourceValue)
        => Map(sourceValue, _mappings.Countries, _defaults.Country);

    public string Currency(string? sourceValue)
        => Map(sourceValue, _mappings.Currencies, _defaults.Currency);

    public string TaxRule(string? sourceValue)
        => Map(sourceValue, _mappings.TaxRules, _defaults.TaxRule);

    public string PaymentTerm(string? sourceValue)
        => Map(sourceValue, _mappings.PaymentTerms, _defaults.PaymentTerm);

    public string AccountingCode(string? sourceValue)
        => Map(sourceValue, _mappings.AccountingCodes, _defaults.AccountingCode);

    public string CustomerCategory(string? sourceValue)
        => Map(sourceValue, _mappings.CustomerCategories, FirstNonBlank(sourceValue, _defaults.CustomerCategory));

    public string OptionalFieldCode(string? sourceValue)
        => Map(sourceValue, _mappings.OptionalFieldCodes, NormalizeCode(sourceValue));

    public int ActiveFlag(string? sourceStatus)
    {
        if (string.IsNullOrWhiteSpace(sourceStatus))
            return _defaults.ActiveValue;

        var status = sourceStatus.Trim();
        return status.Equals("inactive", StringComparison.OrdinalIgnoreCase)
            || status.Equals("no", StringComparison.OrdinalIgnoreCase)
            || status.Equals("false", StringComparison.OrdinalIgnoreCase)
            || status.Equals("0", StringComparison.OrdinalIgnoreCase)
                ? _defaults.InactiveValue
                : _defaults.ActiveValue;
    }

    public static string Truncate(string? value, int maxLength)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        var trimmed = value.Trim();
        return trimmed.Length <= maxLength
            ? trimmed
            : trimmed[..maxLength];
    }

    public static string FirstNonBlank(params string?[] values)
    {
        foreach (var value in values)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();
        }

        return string.Empty;
    }

    public static string NormalizeCode(string? value)
        => string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : value.Trim().ToUpperInvariant();

    private static string Map(
        string? sourceValue,
        IReadOnlyDictionary<string, string> mappings,
        string fallback)
    {
        var normalized = NormalizeCode(sourceValue);

        if (!string.IsNullOrWhiteSpace(normalized)
            && mappings.TryGetValue(normalized, out var mapped)
            && !string.IsNullOrWhiteSpace(mapped))
        {
            return mapped.Trim();
        }

        return string.IsNullOrWhiteSpace(fallback)
            ? normalized
            : fallback.Trim();
    }
}
