namespace Sage300API.SDK.Models.AR;

public class ARCustomer
{
    public string? CustomerNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? ShortName { get; set; }

    public string? GroupCode { get; set; }

    public string? Status { get; set; }

    public string? CurrencyCode { get; set; }

    public string? Terms { get; set; }

    public string? TaxGroup { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ContactName { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? StateProvince { get; set; }

    public string? ZipPostalCode { get; set; }

    public string? Country { get; set; }

    public decimal CreditLimitCustomerCurrency { get; set; }

    public decimal BalanceDueInCustomerCurrency { get; set; }

    public List<CustomerOptionalFieldValue>
        CustomerOptionalFieldValues
    { get; set; } = [];

    public List<CustomerContactSelection>
        CustomerContactSelection
    { get; set; } = [];
}