namespace Sage300API.SDK.Models.AR;

public class ARCustomerGroup
{
    public string? GroupCode { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? InactiveDate { get; set; }

    public DateTime? DateLastMaintained { get; set; }

    public string? AccountSet { get; set; }

    public string? Terms { get; set; }

    public string? TaxGroup { get; set; }

    public decimal CreditLimit1Amount { get; set; }

    public decimal CreditLimit2Amount { get; set; }

    public decimal CreditLimit3Amount { get; set; }

    public decimal CreditLimit4Amount { get; set; }

    public decimal CreditLimit5Amount { get; set; }

    public List<CustomerGroupOptionalFieldValue>
        CustomerGroupOptionalFieldValue
    { get; set; } = [];
}