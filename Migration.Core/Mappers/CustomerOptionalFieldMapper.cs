using System.Globalization;
using Migration.Core.Transformation;
using Sage300API.SDK.Models.AR;

namespace Migration.Core.Mappers;

public sealed class CustomerOptionalFieldMapper
{
    private readonly ValueTransformer _transformer;

    public CustomerOptionalFieldMapper(ValueTransformer transformer)
    {
        _transformer = transformer;
    }

    public Dictionary<string, string?> Map(
        IEnumerable<CustomerOptionalFieldValue>? sourceOptionalFields)
    {
        var result = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

        if (sourceOptionalFields == null)
            return result;

        foreach (var source in sourceOptionalFields)
        {
            var code = _transformer.OptionalFieldCode(source.OptionalField);
            if (string.IsNullOrWhiteSpace(code))
                continue;

            result[code] = GetBestValue(source);
        }

        return result;
    }

    private static string? GetBestValue(CustomerOptionalFieldValue source)
    {
        if (!string.IsNullOrWhiteSpace(source.Value))
            return source.Value.Trim();

        if (!string.IsNullOrWhiteSpace(source.TextValue))
            return source.TextValue.Trim();

        if (source.AmountValue.HasValue)
            return source.AmountValue.Value.ToString(CultureInfo.InvariantCulture);

        if (source.NumberValue.HasValue)
            return source.NumberValue.Value.ToString(CultureInfo.InvariantCulture);

        if (source.IntegerValue.HasValue)
            return source.IntegerValue.Value.ToString(CultureInfo.InvariantCulture);

        if (source.YesNoValue.HasValue)
            return source.YesNoValue.Value ? "Yes" : "No";

        if (source.DateValue.HasValue)
            return source.DateValue.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture);

        if (source.TimeValue.HasValue)
            return source.TimeValue.Value.ToString("HHmmss", CultureInfo.InvariantCulture);

        return null;
    }
}
