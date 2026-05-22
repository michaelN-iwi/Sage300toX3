namespace Sage300API.SDK.Models.AR;

public class CustomerContactSelection
{
    public string? CustomerNumber { get; set; }

    public string? ContactCode { get; set; }

    public string? SelectApplication { get; set; }

    public int FormCount { get; set; }

    public string? ContactName { get; set; }

    public string? Email { get; set; }

    public bool ARInvoices { get; set; }

    public bool ARReceipts { get; set; }

    public bool ARStatements { get; set; }

    public bool OEOrderConfirmations { get; set; }

    public bool OEInvoices { get; set; }

    public bool OECreditDebitNotes { get; set; }

    public bool OEQuotes { get; set; }

    public string? UpdateOperation { get; set; }

    public List<Warning> Warnings { get; set; } = [];
}