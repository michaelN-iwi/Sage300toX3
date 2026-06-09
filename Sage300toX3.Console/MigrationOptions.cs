namespace Sage300toX3.ConsoleApp;

public sealed class MigrationOptions
{
    public int BatchSize { get; init; } = 500;

    public bool ContinueOnError { get; init; } = true;

    public string LogFolder { get; init; } = "Logs";

    /// <summary>
    /// Maximum number of Customer optional fields supported by the current S300BPC web service.
    /// This value depends on the DIM configured in the X3 web service metadata for YOPTBPC/YOPTBPCV.
    /// </summary>
    public int CustomerOptionalFieldCapacity { get; init; } = 9;
}
