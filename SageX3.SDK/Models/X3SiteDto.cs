using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Site object FCY. Web service public name: S300FCY.
/// Source metadata file: S300FCY.xml.
/// </summary>
public sealed class X3SiteDto
{
    public string? SiteCode { get; set; }             // FCY, len 5
    public string? SiteName { get; set; }             // FCYNAM, len 35
    public string? ShortDescription { get; set; }     // FCYSHO, len 10
    public string? LegalCompany { get; set; }         // LEGCPY, len 5
    public string? Country { get; set; }              // CRY, len 3
    public string? TaxIdNumber { get; set; }          // CRN, len 20
    public string? SicCode { get; set; }              // NAF, len 10

    public int? IsFinancialSite { get; set; } = 2;    // FINFLG
    public string? FinancialSite { get; set; }        // FINRSPFCY, len 5
    public string? AccountingCode { get; set; }       // ACCCOD, len 10

    public string? AddressCode { get; set; } = "001";
    public string? AddressDescription { get; set; }
    public string? AddressCountry { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? Email1 { get; set; }
    public string? Website { get; set; }
    public int? IsDefaultAddress { get; set; } = 2;

    public string ToX3Xml()
    {
        Validate();

        var addressCountry = AddressCountry ?? Country;
        var addressDescription = AddressDescription ?? SiteName;
        var financialSite = FinancialSite ?? SiteCode;

        return new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("FCY0_1")
                    .Field("FCY", SiteCode)
                    .Field("FCYNAM", SiteName)
                .EndGroup()
                .BeginGroup("FCY1_1")
                    .Field("FCYSHO", ShortDescription)
                    .Field("LEGCPY", LegalCompany)
                    .Field("CRY", Country)
                    .Field("CRN", TaxIdNumber)
                    .Field("NAF", SicCode)
                .EndGroup()
                .BeginGroup("FCY4_1")
                    .Field("FINFLG", IsFinancialSite)
                    .Field("FINRSPFCY", financialSite)
                    .Field("ACCCOD", AccountingCode)
                .EndGroup()
                .BeginTable("BPF_1", 1)
                    .BeginLine(1)
                        .Field("CODADR", AddressCode)
                        .Field("BPADES", addressDescription)
                        .Field("BPACRY", addressCountry)
                        .Field("ADDLIG1", AddressLine1)
                        .Field("ADDLIG2", AddressLine2)
                        .Field("ADDLIG3", AddressLine3)
                        .Field("POSCOD", PostalCode)
                        .Field("CTY", City)
                        .Field("SAT", StateProvince)
                        .Field("TEL1", Phone1)
                        .Field("TEL2", Phone2)
                        .Field("WEB1", Email1)
                        .Field("FCYWEB", Website)
                        .Field("BPAADDFLG", IsDefaultAddress)
                    .EndLine()
                .EndTable()
            .EndObject()
            .Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(SiteCode, nameof(SiteCode));
        SageX3Validation.Required(SiteName, nameof(SiteName));
        SageX3Validation.Required(ShortDescription, nameof(ShortDescription));
        SageX3Validation.Required(LegalCompany, nameof(LegalCompany));
        SageX3Validation.Required(Country, nameof(Country));
        SageX3Validation.Required(AccountingCode, nameof(AccountingCode));

        SageX3Validation.Max(SiteCode, 5, nameof(SiteCode));
        SageX3Validation.Max(SiteName, 35, nameof(SiteName));
        SageX3Validation.Max(ShortDescription, 10, nameof(ShortDescription));
        SageX3Validation.Max(LegalCompany, 5, nameof(LegalCompany));
        SageX3Validation.Max(Country, 3, nameof(Country));
        SageX3Validation.Max(AccountingCode, 10, nameof(AccountingCode));
        SageX3Validation.Max(AddressCode, 5, nameof(AddressCode));
    }
}
