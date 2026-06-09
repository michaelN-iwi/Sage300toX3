using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Company object CPY. Web service public name: S300CPY.
/// Source metadata file: S300CPY.xml.
/// </summary>
public sealed class X3CompanyDto
{
    public string? CompanyCode { get; set; }          // CPY, len 5
    public string? CompanyName { get; set; }          // CPYNAM, len 35
    public string? ShortDescription { get; set; }     // CPYSHO, len 10

    public int? IsLegalCompany { get; set; } = 2;     // CPYLEGFLG
    public string? Legislation { get; set; }          // LEG, len 20
    public string? LegalForm { get; set; }            // CPYLOG, len 10

    public string? RegisteredCapitalCurrency { get; set; } // RGCCUR, len 3
    public decimal? RegisteredCapitalAmount { get; set; }  // RGCAMT
    public string? MainSite { get; set; }             // MAIFCY, len 5
    public string? Country { get; set; }              // CRY, len 3
    public int? SubjectToTax { get; set; }            // SUBTOTAX
    public string? TaxIdNumber { get; set; }          // CRN, len 20
    public string? SicCode { get; set; }              // NAF, len 10
    public string? NationalId { get; set; }           // NID, len 80
    public string? EuVatNumber { get; set; }          // EECNUM, len 20

    public string? AccountingModel { get; set; }      // ACM, len 3
    public DateTime? StartPeriod { get; set; }        // STRPER
    public string? AccountingCurrency { get; set; }   // ACCCUR, len 3
    public string? AccountingCode { get; set; }       // ACCCOD, len 10

    public string? AddressCode { get; set; } = "001"; // CODADR
    public string? AddressDescription { get; set; }   // BPADES
    public string? AddressCountry { get; set; }       // BPACRY
    public string? AddressLine1 { get; set; }         // ADDLIG1
    public string? AddressLine2 { get; set; }         // ADDLIG2
    public string? AddressLine3 { get; set; }         // ADDLIG3
    public string? PostalCode { get; set; }           // POSCOD
    public string? City { get; set; }                 // CTY
    public string? StateProvince { get; set; }        // SAT
    public string? Phone1 { get; set; }               // TEL1
    public string? Phone2 { get; set; }               // TEL2
    public string? Email1 { get; set; }               // WEB1
    public string? Website { get; set; }              // FCYWEB
    public int? IsDefaultAddress { get; set; } = 2;   // BPAADDFLG

    public string ToX3Xml()
    {
        Validate();

        var addressCountry = AddressCountry ?? Country;
        var addressDescription = AddressDescription ?? CompanyName;

        return new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("CPY0_1")
                    .Field("CPY", CompanyCode)
                    .Field("CPYNAM", CompanyName)
                    .Field("CPYSHO", ShortDescription)
                .EndGroup()
                .BeginGroup("CPY1_1")
                    .Field("CPYLEGFLG", IsLegalCompany)
                    .Field("LEG", Legislation)
                    .Field("CPYLOG", LegalForm)
                .EndGroup()
                .BeginGroup("CPY1_2")
                    .Field("RGCCUR", RegisteredCapitalCurrency)
                    .Field("RGCAMT", RegisteredCapitalAmount)
                    .Field("MAIFCY", MainSite)
                    .Field("CRY", Country)
                    .Field("SUBTOTAX", SubjectToTax)
                    .Field("CRN", TaxIdNumber)
                    .Field("NAF", SicCode)
                    .Field("NID", NationalId)
                    .Field("EECNUM", EuVatNumber)
                .EndGroup()
                .BeginGroup("CPY3_1")
                    .Field("ACM", AccountingModel)
                    .Field("STRPER", StartPeriod)
                    .Field("ACCCUR", AccountingCurrency)
                    .Field("ACCCOD", AccountingCode)
                .EndGroup()
                .BeginTable("BPA_1", 1)
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
        SageX3Validation.Required(CompanyCode, nameof(CompanyCode));
        SageX3Validation.Required(CompanyName, nameof(CompanyName));
        SageX3Validation.Required(ShortDescription, nameof(ShortDescription));
        SageX3Validation.Required(Legislation, nameof(Legislation));
        SageX3Validation.Required(Country, nameof(Country));
        SageX3Validation.Required(AccountingCurrency, nameof(AccountingCurrency));
        SageX3Validation.Required(AccountingCode, nameof(AccountingCode));

        SageX3Validation.Max(CompanyCode, 5, nameof(CompanyCode));
        SageX3Validation.Max(CompanyName, 35, nameof(CompanyName));
        SageX3Validation.Max(ShortDescription, 10, nameof(ShortDescription));
        SageX3Validation.Max(Legislation, 20, nameof(Legislation));
        SageX3Validation.Max(LegalForm, 10, nameof(LegalForm));
        SageX3Validation.Max(Country, 3, nameof(Country));
        SageX3Validation.Max(AccountingCurrency, 3, nameof(AccountingCurrency));
        SageX3Validation.Max(AccountingCode, 10, nameof(AccountingCode));
        SageX3Validation.Max(AddressCode, 5, nameof(AddressCode));
    }
}
