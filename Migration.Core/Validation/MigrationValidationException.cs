namespace Migration.Core.Validation;

public sealed class MigrationValidationException : Exception
{
    public MigrationValidationException(MigrationValidationResult result)
        : base(BuildMessage(result))
    {
        Result = result;
    }

    public MigrationValidationResult Result { get; }

    private static string BuildMessage(MigrationValidationResult result)
    {
        var errors = result.Issues
            .Where(issue => issue.Severity == ValidationSeverity.Error)
            .Select(issue => $"{issue.EntityName} [{issue.SourceKey}] {issue.FieldName}: {issue.Message}");

        return string.Join(Environment.NewLine, errors);
    }
}
