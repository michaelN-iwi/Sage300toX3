using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Fiscal Year object FIY. Web service public name: S300FIY.
/// Source metadata file: S300FIY.xml.
/// </summary>
public sealed class X3FiscalYearDto
{
    public string? CompanyCode { get; set; }          // CPY, len 5
    public int? LedgerType { get; set; }              // LEDTYP
    public List<X3FiscalYearLineDto> FiscalYears { get; set; } = new(); // FIY1_2

    public string ToX3Xml()
    {
        Validate();

        var builder = new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("FIY1_1")
                    .Field("CPY", CompanyCode)
                    .Field("LEDTYP", LedgerType)
                .EndGroup();

        builder.BeginTable("FIY1_2", FiscalYears.Count);
        for (var index = 0; index < FiscalYears.Count; index++)
        {
            var line = FiscalYears[index];
            builder.BeginLine(index + 1)
                .Field("NO", line.LineNumber)
                .Field("FIYNUM", line.FiscalYearNumber)
                .Field("DES", line.Description)
                .Field("DESSHO", line.ShortDescription)
                .Field("FIYSTR", line.StartDate)
                .Field("FIYEND", line.EndDate)
            .EndLine();
        }
        builder.EndTable();

        return builder.EndObject().Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(CompanyCode, nameof(CompanyCode));
        SageX3Validation.Required(LedgerType, nameof(LedgerType));
        SageX3Validation.Max(CompanyCode, 5, nameof(CompanyCode));
        SageX3Validation.MaxCount(FiscalYears.Count, 99, nameof(FiscalYears));

        if (FiscalYears.Count == 0)
            throw new InvalidOperationException("At least one fiscal year line is required.");
    }
}

public sealed class X3FiscalYearLineDto
{
    public int? LineNumber { get; set; }              // NO
    public int? FiscalYearNumber { get; set; }        // FIYNUM
    public string? Description { get; set; }          // DES, len 30
    public string? ShortDescription { get; set; }     // DESSHO, len 10
    public DateTime? StartDate { get; set; }          // FIYSTR
    public DateTime? EndDate { get; set; }            // FIYEND
}
