using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Period object PER. Web service public name: S300PER.
/// Source metadata file: S300PER.xml.
/// </summary>
public sealed class X3PeriodDto
{
    public string? CompanyCode { get; set; }          // CPY, len 5
    public int? LedgerType { get; set; }              // LEDTYP
    public int? FiscalYearNumber { get; set; }        // FIYNUM
    public List<X3PeriodLineDto> Periods { get; set; } = new(); // PER1_2

    public string ToX3Xml()
    {
        Validate();

        var builder = new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("PER1_1")
                    .Field("CPY", CompanyCode)
                    .Field("LEDTYP", LedgerType)
                    .Field("FIYNUM", FiscalYearNumber)
                .EndGroup();

        builder.BeginTable("PER1_2", Periods.Count);
        for (var index = 0; index < Periods.Count; index++)
        {
            var line = Periods[index];
            builder.BeginLine(index + 1)
                .Field("PERNUM", line.PeriodNumber)
                .Field("PERSTR", line.StartDate)
                .Field("PEREND", line.EndDate)
                .Field("PERSTOSTA", line.StockStatus)
            .EndLine();
        }
        builder.EndTable();

        return builder.EndObject().Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(CompanyCode, nameof(CompanyCode));
        SageX3Validation.Required(LedgerType, nameof(LedgerType));
        SageX3Validation.Required(FiscalYearNumber, nameof(FiscalYearNumber));
        SageX3Validation.Max(CompanyCode, 5, nameof(CompanyCode));
        SageX3Validation.MaxCount(Periods.Count, 28, nameof(Periods));

        if (Periods.Count == 0)
            throw new InvalidOperationException("At least one period line is required.");
    }
}

public sealed class X3PeriodLineDto
{
    public int? PeriodNumber { get; set; }            // PERNUM
    public DateTime? StartDate { get; set; }          // PERSTR
    public DateTime? EndDate { get; set; }            // PEREND
    public int? StockStatus { get; set; }             // PERSTOSTA
}
