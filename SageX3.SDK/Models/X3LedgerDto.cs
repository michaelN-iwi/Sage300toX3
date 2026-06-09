using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Ledger object LED. Web service public name: S300LED.
/// Source metadata file: S300LED.xml.
/// </summary>
public sealed class X3LedgerDto
{
    public string? LedgerCode { get; set; }           // LED, len 3
    public string? Description { get; set; }          // DESTRA, len 30
    public string? ShortDescription { get; set; }     // SHOTRA, len 12
    public string? Legislation { get; set; }          // LEG, len 20

    public int? GeneralLedger { get; set; }           // GEN
    public int? AnalyticalLedger { get; set; }        // ANA
    public int? BudgetLedger { get; set; }            // BUD
    public int? LedgerType { get; set; }              // LEDTYPE

    public int? Balance { get; set; }                 // BAL
    public int? SiteBalance { get; set; }             // FCYBAL
    public int? Matching { get; set; }                // MTCFLG
    public int? DimensionByCompany { get; set; }      // DIEDACOBY
    public int? InputDimension { get; set; }          // DIEIPT

    public string? ChartOfAccounts { get; set; }      // COA, len 3
    public int? DimensionCount { get; set; }          // DIENBR
    public List<string> Dimensions { get; set; } = new(); // DIE DIM 9

    public int? GeneralType { get; set; }             // GENTYP
    public int? BalanceAnalyticalRank { get; set; }   // EQLRANANA
    public int? EndVoucher { get; set; }              // ENDVCR
    public int? AccountVoucher { get; set; }          // ACCVCR

    public string ToX3Xml(int dimensionCapacity = 9)
    {
        Validate(dimensionCapacity);

        var builder = new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("LED1_1")
                    .Field("LED", LedgerCode)
                    .Field("DESTRA", Description)
                .EndGroup()
                .BeginGroup("LED1_2")
                    .Field("SHOTRA", ShortDescription)
                    .Field("LEG", Legislation)
                .EndGroup()
                .BeginGroup("LED1_3")
                    .Field("GEN", GeneralLedger)
                    .Field("ANA", AnalyticalLedger)
                    .Field("BUD", BudgetLedger)
                    .Field("LEDTYPE", LedgerType)
                .EndGroup()
                .BeginGroup("LED1_4")
                    .Field("BAL", Balance)
                    .Field("FCYBAL", SiteBalance)
                    .Field("MTCFLG", Matching)
                    .Field("DIEDACOBY", DimensionByCompany)
                    .Field("DIEIPT", InputDimension)
                .EndGroup()
                .BeginGroup("LED1_5")
                    .Field("COA", ChartOfAccounts)
                    .Field("DIENBR", DimensionCount);

        builder.BeginList("DIE", dimensionCapacity);
        for (var index = 0; index < dimensionCapacity; index++)
        {
            builder.ListItem(index < Dimensions.Count ? Dimensions[index] : string.Empty);
        }
        builder.EndList();

        return builder
                .EndGroup()
                .BeginGroup("LED1_6")
                    .Field("GENTYP", GeneralType)
                    .Field("EQLRANANA", BalanceAnalyticalRank)
                    .Field("ENDVCR", EndVoucher)
                    .Field("ACCVCR", AccountVoucher)
                .EndGroup()
            .EndObject()
            .Build();
    }

    public void Validate(int dimensionCapacity = 9)
    {
        SageX3Validation.Required(LedgerCode, nameof(LedgerCode));
        SageX3Validation.Required(Description, nameof(Description));
        SageX3Validation.Required(ShortDescription, nameof(ShortDescription));
        SageX3Validation.Required(Legislation, nameof(Legislation));
        SageX3Validation.Required(ChartOfAccounts, nameof(ChartOfAccounts));

        SageX3Validation.Max(LedgerCode, 3, nameof(LedgerCode));
        SageX3Validation.Max(Description, 30, nameof(Description));
        SageX3Validation.Max(ShortDescription, 12, nameof(ShortDescription));
        SageX3Validation.Max(Legislation, 20, nameof(Legislation));
        SageX3Validation.Max(ChartOfAccounts, 3, nameof(ChartOfAccounts));
        SageX3Validation.MaxCount(Dimensions.Count, dimensionCapacity, nameof(Dimensions));

        foreach (var dimension in Dimensions)
        {
            SageX3Validation.Max(dimension, 3, nameof(Dimensions));
        }
    }
}
