namespace Sage300API.SDK.Models.AR;

public class CustomerOptionalFieldValue
{
    public string? CustomerNumber { get; set; }

    public string? OptionalField { get; set; }

    public string? Value { get; set; }

    public string? CustomerOptionalFieldValueType { get; set; }

    public int Length { get; set; }

    public int Decimals { get; set; }

    public bool AllowBlank { get; set; }

    public bool Validate { get; set; }

    public string? ValueSet { get; set; }

    public int TypedValueFieldIndex { get; set; }

    public string? TextValue { get; set; }

    public decimal? AmountValue { get; set; }

    public decimal? NumberValue { get; set; }

    public int? IntegerValue { get; set; }

    public bool? YesNoValue { get; set; }

    public DateTime? DateValue { get; set; }

    public DateTime? TimeValue { get; set; }

    public string? OptionalFieldDescription { get; set; }

    public string? ValueDescription { get; set; }

    public string? UpdateOperation { get; set; }

    public List<Warning> Warnings { get; set; } = [];
}