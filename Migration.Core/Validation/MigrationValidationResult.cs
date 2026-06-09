namespace Migration.Core.Validation;

public sealed class MigrationValidationResult
{
    private readonly List<ValidationIssue> _issues = new();

    public IReadOnlyList<ValidationIssue> Issues => _issues;

    public bool IsValid => !_issues.Any(issue => issue.Severity == ValidationSeverity.Error);

    public void AddError(
        string entityName,
        string sourceKey,
        string fieldName,
        string message)
    {
        _issues.Add(new ValidationIssue(
            ValidationSeverity.Error,
            entityName,
            sourceKey,
            fieldName,
            message));
    }

    public void AddWarning(
        string entityName,
        string sourceKey,
        string fieldName,
        string message)
    {
        _issues.Add(new ValidationIssue(
            ValidationSeverity.Warning,
            entityName,
            sourceKey,
            fieldName,
            message));
    }

    public void ThrowIfInvalid()
    {
        if (!IsValid)
            throw new MigrationValidationException(this);
    }
}
