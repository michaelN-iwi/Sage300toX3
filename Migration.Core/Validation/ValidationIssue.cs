namespace Migration.Core.Validation;

public sealed class ValidationIssue
{
    public ValidationIssue(
        ValidationSeverity severity,
        string entityName,
        string sourceKey,
        string fieldName,
        string message)
    {
        Severity = severity;
        EntityName = entityName;
        SourceKey = sourceKey;
        FieldName = fieldName;
        Message = message;
    }

    public ValidationSeverity Severity { get; }

    public string EntityName { get; }

    public string SourceKey { get; }

    public string FieldName { get; }

    public string Message { get; }
}
