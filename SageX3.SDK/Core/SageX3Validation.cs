namespace SageX3.SDK.Core;

public static class SageX3Validation
{
    public static void Required(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException($"Missing required field: {fieldName}");
    }

    public static void Required<T>(T? value, string fieldName)
        where T : struct
    {
        if (!value.HasValue)
            throw new InvalidOperationException($"Missing required field: {fieldName}");
    }

    public static void Max(string? value, int maxLength, string fieldName)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            throw new InvalidOperationException(
                $"Field {fieldName} exceeds max length {maxLength}. Current length: {value.Length}");
    }

    public static void MaxCount(int count, int maxCount, string fieldName)
    {
        if (count > maxCount)
            throw new InvalidOperationException(
                $"Field {fieldName} supports a maximum of {maxCount} entries. Current count: {count}");
    }
}
