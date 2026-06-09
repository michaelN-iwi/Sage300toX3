namespace Migration.Core.Options;

public sealed class MigrationMappingOptions
{
    public Dictionary<string, string> Countries { get; init; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, string> Currencies { get; init; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, string> TaxRules { get; init; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, string> PaymentTerms { get; init; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, string> AccountingCodes { get; init; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, string> CustomerCategories { get; init; } = new(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, string> OptionalFieldCodes { get; init; } = new(StringComparer.OrdinalIgnoreCase);
}
