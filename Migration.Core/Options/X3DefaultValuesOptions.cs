namespace Migration.Core.Options;

public sealed class X3DefaultValuesOptions
{
    public string Country { get; init; } = "CA";

    public string Language { get; init; } = "ENG";

    public string Currency { get; init; } = "CAD";

    public string AddressCode { get; init; } = "001";

    public string AddressDescription { get; init; } = "Main Address";

    public string TaxIdNumber { get; init; } = "999999999";

    public string TaxRule { get; init; } = "ON";

    public string PaymentTerm { get; init; } = "NET30";

    public string AccountingCode { get; init; } = "STD";

    public string CustomerCategory { get; init; } = "TST";

    public int ActiveValue { get; init; } = 2;

    public int InactiveValue { get; init; } = 1;
}
