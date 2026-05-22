namespace Sage300toX3.ConsoleApp;

public sealed class MigrationOptions
{
    public int BatchSize { get; init; } = 500;

    public bool ContinueOnError { get; init; } = true;

    public string LogFolder { get; init; } = "Logs";
}
