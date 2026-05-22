using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Customer Category object BCG. Web service public name: S300CRMCAT.
/// Source metadata file: S300CRMCAT.xml.
/// </summary>
public sealed class X3CustomerCategoryDto
{
    public string? CategoryCode { get; set; }          // BCGCOD, len 5
    public string? Description { get; set; }           // DESAXX, len 30
    public string? ShortDescription { get; set; }      // SHOAXX, len 12
    public string? CustomerSequence { get; set; }      // REFCOU, len 5
    public int? CreationMethod { get; set; }           // CREMOD

    public string? Country { get; set; }               // CRY, len 3
    public string? Language { get; set; }              // LAN, len 3
    public string? Currency { get; set; }              // CUR, len 3
    public int? CustomerType { get; set; }             // BPCTYP
    public int? RateType { get; set; }                 // CHGTYP

    public int? CreditControl { get; set; }            // OSTCTL
    public decimal? AuthorizedCredit { get; set; }     // WOSTAUZ

    public string? AccountingCode { get; set; }        // ACCCOD
    public string? AccountStructure { get; set; }      // DIA
    public string? TaxRule { get; set; }               // VACBPR
    public string? PaymentTerm { get; set; }           // PTE
    public string? SettlementDiscount { get; set; }    // DEP
    public string? PaymentBank { get; set; }           // PAYBAN
    public string? ReminderGroup { get; set; }         // GRP

    public string ToX3Xml()
    {
        return new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("BCG0_1")
                    .Field("BCGCOD", CategoryCode)
                    .Field("DESAXX", Description)
                .EndGroup()
                .BeginGroup("BCGI_1")
                    .Field("SHOAXX", ShortDescription)
                    .Field("REFCOU", CustomerSequence)
                    .Field("CREMOD", CreationMethod)
                .EndGroup()
                .BeginGroup("BCGI_2")
                    .Field("CRY", Country)
                    .Field("LAN", Language)
                    .Field("CUR", Currency)
                    .Field("BPCTYP", CustomerType)
                    .Field("CHGTYP", RateType)
                .EndGroup()
                .BeginGroup("BCGI_4")
                    .Field("OSTCTL", CreditControl)
                    .Field("WOSTAUZ", AuthorizedCredit)
                .EndGroup()
                .BeginGroup("BCG3_1")
                    .Field("ACCCOD", AccountingCode)
                    .Field("DIA", AccountStructure)
                    .Field("VACBPR", TaxRule)
                .EndGroup()
                .BeginGroup("BCG3_2")
                    .Field("PTE", PaymentTerm)
                    .Field("DEP", SettlementDiscount)
                    .Field("PAYBAN", PaymentBank)
                    .Field("GRP", ReminderGroup)
                .EndGroup()
            .EndObject()
            .Build();
    }
}
