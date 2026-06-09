using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Ledger Group / Ledger Model object GCM. Web service public name: S300GCM.
/// Source metadata file: S300GCM.xml.
/// </summary>
public sealed class X3LedgerGroupDto
{
    public string? LedgerGroupCode { get; set; }      // GCM, len 3
    public string? Description { get; set; }          // DESTRA, len 30
    public string? ShortDescription { get; set; }     // SHOTRA, len 12
    public string? Legislation { get; set; }          // LEG, len 20
    public int? IasFlag { get; set; }                 // FLGIAS

    public int? MainGeneralLedgerType { get; set; }   // GENLEDTYP
    public int? MainAnalyticalLedgerType { get; set; }// ANALEDTYP
    public int? IasLedgerType { get; set; }           // IASLEDTYP

    public List<X3LedgerGroupLedgerLineDto> Ledgers { get; set; } = new(); // GCM1_4
    public List<X3LedgerGroupControlLineDto> Controls { get; set; } = new(); // GCM1_5

    public string ToX3Xml()
    {
        Validate();

        var builder = new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("GCM1_1")
                    .Field("GCM", LedgerGroupCode)
                    .Field("DESTRA", Description)
                .EndGroup()
                .BeginGroup("GCM1_2")
                    .Field("SHOTRA", ShortDescription)
                    .Field("LEG", Legislation)
                    .Field("FLGIAS", IasFlag)
                .EndGroup()
                .BeginGroup("GCM1_3")
                    .Field("GENLEDTYP", MainGeneralLedgerType)
                    .Field("ANALEDTYP", MainAnalyticalLedgerType)
                    .Field("IASLEDTYP", IasLedgerType)
                .EndGroup();

        if (Ledgers.Count > 0)
        {
            builder.BeginTable("GCM1_4", Ledgers.Count);
            for (var index = 0; index < Ledgers.Count; index++)
            {
                var line = Ledgers[index];
                builder.BeginLine(index + 1)
                    .Field("LEDTYP", line.LedgerType)
                    .Field("CFMAUT", line.AutomaticConversion)
                    .Field("ORILEDTYP", line.SourceLedgerType)
                    .Field("LED", line.LedgerCode)
                    .Field("CUR", line.Currency)
                    .Field("FLGVCRRAT", line.VoucherRateFlag)
                    .Field("TYPRAT", line.RateType)
                    .Field("DACRAT", line.RateDate)
                    .Field("RNDOPTBAL", line.RoundBalance)
                .EndLine();
            }
            builder.EndTable();
        }

        if (Controls.Count > 0)
        {
            builder.BeginTable("GCM1_5", Controls.Count);
            for (var index = 0; index < Controls.Count; index++)
            {
                var line = Controls[index];
                builder.BeginLine(index + 1)
                    .Field("LED1", line.Ledger1)
                    .Field("LED2", line.Ledger2)
                    .Field("CTLTYP", line.ControlType)
                .EndLine();
            }
            builder.EndTable();
        }

        return builder.EndObject().Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(LedgerGroupCode, nameof(LedgerGroupCode));
        SageX3Validation.Required(Description, nameof(Description));
        SageX3Validation.Required(ShortDescription, nameof(ShortDescription));
        SageX3Validation.Required(Legislation, nameof(Legislation));

        SageX3Validation.Max(LedgerGroupCode, 3, nameof(LedgerGroupCode));
        SageX3Validation.Max(Description, 30, nameof(Description));
        SageX3Validation.Max(ShortDescription, 12, nameof(ShortDescription));
        SageX3Validation.Max(Legislation, 20, nameof(Legislation));
        SageX3Validation.MaxCount(Ledgers.Count, 10, nameof(Ledgers));
        SageX3Validation.MaxCount(Controls.Count, 10, nameof(Controls));
    }
}

public sealed class X3LedgerGroupLedgerLineDto
{
    public int? LedgerType { get; set; }              // LEDTYP
    public int? AutomaticConversion { get; set; }     // CFMAUT
    public int? SourceLedgerType { get; set; }        // ORILEDTYP
    public string? LedgerCode { get; set; }           // LED, len 3
    public string? Currency { get; set; }             // CUR, len 3
    public int? VoucherRateFlag { get; set; }         // FLGVCRRAT
    public int? RateType { get; set; }                // TYPRAT
    public int? RateDate { get; set; }                // DACRAT
    public int? RoundBalance { get; set; }            // RNDOPTBAL
}

public sealed class X3LedgerGroupControlLineDto
{
    public string? Ledger1 { get; set; }              // LED1, len 3
    public string? Ledger2 { get; set; }              // LED2, len 3
    public string? ControlType { get; set; }          // CTLTYP, len 3
}
