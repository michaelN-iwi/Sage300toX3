using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Customer object BPC. Web service public name: S300BPC.
/// Source metadata file: S300BPC.xml.
/// Customer optional fields are embedded in S300BPC using YOPTBPC/YOPTBPCV dimensional fields.
/// </summary>
public sealed class X3CustomerDto
{
    public string? CustomerNumber { get; set; }        // BPCNUM, len 15
    public string? CategoryCode { get; set; }          // BCGCOD, len 5
    public int? IsActive { get; set; } = 2;            // BPCSTA, local menu yes/no. Commonly 2=Yes, 1=No.

    public string? ShortDescription { get; set; }      // BPRSHO, len 10
    public string? Acronym { get; set; }               // BPRLOG, len 10
    public string? NameLine1 { get; set; }             // BPRNAM IDX 1, len 35
    public string? NameLine2 { get; set; }             // BPRNAM IDX 2, len 35
    public string? Country { get; set; }               // CRY, len 3
    public int? SubjectToTax { get; set; }             // SUBTOTAX
    public string? Language { get; set; }              // LAN, len 3
    public string? Currency { get; set; }              // CUR, len 3
    public string? TaxIdNumber { get; set; }           // CRN, len 20
    public string? SicCode { get; set; }               // NAF, len 10
    public string? EuVatNumber { get; set; }           // EECNUM, len 20

    public string? AddressCode { get; set; } = "001"; // CODADR, len 5
    public string? AddressDescription { get; set; }    // BPADES, len 30
    public string? AddressCountry { get; set; }        // BPACRY, len 3
    public string? AddressLine1 { get; set; }          // ADDLIG1, len 50
    public string? AddressLine2 { get; set; }          // ADDLIG2, len 50
    public string? AddressLine3 { get; set; }          // ADDLIG3, len 50
    public string? PostalCode { get; set; }            // POSCOD, len 10
    public string? City { get; set; }                  // CTY, len 40
    public string? StateProvince { get; set; }         // SAT, len 35
    public string? Phone1 { get; set; }                // TEL1, len 20
    public string? Phone2 { get; set; }                // TEL2, len 20
    public string? Email1 { get; set; }                // WEB1, len 80
    public string? Email2 { get; set; }                // WEB2, len 80
    public string? Website { get; set; }               // FCYWEB, len 250
    public string? ExternalIdentifier { get; set; }    // EXTNUM, len 30
    public int? IsDefaultAddress { get; set; } = 2;    // BPAADDFLG

    public int? CustomerType { get; set; }             // BPCTYP
    public int? RateType { get; set; }                 // CHGTYP
    public int? CreditControl { get; set; }            // OSTCTL
    public decimal? AuthorizedCredit { get; set; }     // WOSTAUZ

    public string? BillToCustomer { get; set; }        // BPCINV
    public string? PayByCustomer { get; set; }         // BPCPYR
    public string? GroupCustomer { get; set; }         // BPCGRU
    public string? RiskCustomer { get; set; }          // BPCRSK
    public string? AccountingCode { get; set; }        // ACCCOD
    public string? AccountStructure { get; set; }      // DIA
    public string? TaxRule { get; set; }               // VACBPR
    public string? PaymentTerm { get; set; }           // PTE
    public string? SettlementDiscount { get; set; }    // DEP
    public string? PaymentBank { get; set; }           // PAYBAN
    public string? ReminderGroup { get; set; }         // GRP

    /// <summary>
    /// Customer optional fields embedded in S300BPC.
    /// Key maps to YOPTBPC and value maps to YOPTBPCV.
    /// The generated IDX position keeps code/value aligned.
    /// </summary>
    public Dictionary<string, string?> OptionalFields { get; set; } = new();

    public string ToX3Xml(int optionalFieldCapacity = 9)
    {
        Validate(optionalFieldCapacity);

        var addressCountry = AddressCountry ?? Country;
        var addressDescription = AddressDescription ?? NameLine1;
        var billTo = BillToCustomer ?? CustomerNumber;
        var payBy = PayByCustomer ?? CustomerNumber;
        var groupCustomer = GroupCustomer ?? CustomerNumber;
        var riskCustomer = RiskCustomer ?? CustomerNumber;

        var builder = new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("BPC0_1")
                    .Field("BCGCOD", CategoryCode)
                    .Field("BPCSTA", IsActive)
                    .Field("BPCNUM", CustomerNumber)
                .EndGroup()
                .BeginGroup("BPRC_1")
                    .Field("BPRSHO", ShortDescription)
                    .Field("BPRLOG", Acronym)
                    .Field("BPRNAM", NameLine1, 1)
                    .Field("BPRNAM", NameLine2, 2)
                    .Field("CRY", Country)
                    .Field("SUBTOTAX", SubjectToTax)
                    .Field("LAN", Language)
                    .Field("CUR", Currency)
                    .Field("CRN", TaxIdNumber)
                    .Field("NAF", SicCode)
                    .Field("EECNUM", EuVatNumber)
                .EndGroup()
                .BeginTable("BPAC_1", 1)
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
                        .Field("WEB2", Email2)
                        .Field("FCYWEB", Website)
                        .Field("EXTNUM", ExternalIdentifier)
                        .Field("BPAADDFLG", IsDefaultAddress)
                    .EndLine()
                .EndTable()
                .BeginGroup("BPC2_1")
                    .Field("BPCTYP", CustomerType)
                    .Field("CHGTYP", RateType)
                .EndGroup()
                .BeginGroup("BPC2_2")
                    .Field("OSTCTL", CreditControl)
                    .Field("WOSTAUZ", AuthorizedCredit)
                .EndGroup()
                .BeginGroup("BPC3_1")
                    .Field("BPCINV", billTo)
                    .Field("BPAINV", AddressCode)
                    .Field("BPCPYR", payBy)
                    .Field("BPAPYR", AddressCode)
                    .Field("BPCGRU", groupCustomer)
                    .Field("BPCRSK", riskCustomer)
                    .Field("ACCCOD", AccountingCode)
                    .Field("DIA", AccountStructure)
                .EndGroup()
                .BeginGroup("BPC3_2")
                    .Field("VACBPR", TaxRule)
                .EndGroup()
                .BeginGroup("BPC3_3")
                    .Field("PTE", PaymentTerm)
                    .Field("DEP", SettlementDiscount)
                    .Field("PAYBAN", PaymentBank)
                    .Field("GRP", ReminderGroup)
                .EndGroup();

        AppendOptionalFields(builder, optionalFieldCapacity);

        return builder
            .EndObject()
            .Build();
    }

    public void Validate(int optionalFieldCapacity = 9)
    {
        Required(CustomerNumber, nameof(CustomerNumber));
        Required(CategoryCode, nameof(CategoryCode));
        Required(NameLine1, nameof(NameLine1));
        Required(ShortDescription, nameof(ShortDescription));
        Required(Country, nameof(Country));
        Required(Language, nameof(Language));
        Required(Currency, nameof(Currency));
        Required(TaxIdNumber, nameof(TaxIdNumber));
        Required(AddressCode, nameof(AddressCode));
        Required(AddressCountry ?? Country, nameof(AddressCountry));
        Required(TaxRule, nameof(TaxRule));
        Required(PaymentTerm, nameof(PaymentTerm));
        Required(AccountingCode, nameof(AccountingCode));

        Max(CustomerNumber, 15, nameof(CustomerNumber));
        Max(CategoryCode, 5, nameof(CategoryCode));
        Max(ShortDescription, 10, nameof(ShortDescription));
        Max(Acronym, 10, nameof(Acronym));
        Max(NameLine1, 35, nameof(NameLine1));
        Max(NameLine2, 35, nameof(NameLine2));
        Max(Country, 3, nameof(Country));
        Max(Language, 3, nameof(Language));
        Max(Currency, 3, nameof(Currency));
        Max(TaxIdNumber, 20, nameof(TaxIdNumber));
        Max(AddressCode, 5, nameof(AddressCode));
        Max(AddressDescription, 30, nameof(AddressDescription));
        Max(AddressCountry, 3, nameof(AddressCountry));
        Max(AddressLine1, 50, nameof(AddressLine1));
        Max(AddressLine2, 50, nameof(AddressLine2));
        Max(AddressLine3, 50, nameof(AddressLine3));
        Max(City, 40, nameof(City));
        Max(StateProvince, 35, nameof(StateProvince));
        Max(PostalCode, 10, nameof(PostalCode));
        Max(TaxRule, 5, nameof(TaxRule));
        Max(PaymentTerm, 15, nameof(PaymentTerm));
        Max(AccountingCode, 10, nameof(AccountingCode));

        if (optionalFieldCapacity < 0)
            throw new InvalidOperationException("Customer optional field capacity cannot be negative.");

        if (OptionalFields.Count > optionalFieldCapacity)
            throw new InvalidOperationException(
                $"Customer supports a maximum of {optionalFieldCapacity} optional fields, but {OptionalFields.Count} were provided.");

        foreach (var optionalField in OptionalFields)
        {
            Required(optionalField.Key, "OptionalFields.Code");
            Max(optionalField.Key, 50, $"OptionalFields[{optionalField.Key}].Code");
            Max(optionalField.Value, 100, $"OptionalFields[{optionalField.Key}].Value");
        }
    }

    private void AppendOptionalFields(SageX3XmlBuilder builder, int optionalFieldCapacity)
    {
        if (optionalFieldCapacity <= 0)
            return;

        var entries = OptionalFields.ToList();

        builder.BeginGroup("YOPTBPC_1");
        builder.BeginList("YOPTBPC", optionalFieldCapacity);
        for (var index = 0; index < optionalFieldCapacity; index++)
        {
            var code = index < entries.Count ? entries[index].Key : string.Empty;
            builder.ListItem(code);
        }
        builder.EndList();
        builder.EndGroup();

        builder.BeginGroup("YOPTBPC_2");
        builder.BeginList("YOPTBPCV", optionalFieldCapacity);
        for (var index = 0; index < optionalFieldCapacity; index++)
        {
            var value = index < entries.Count ? entries[index].Value : string.Empty;
            builder.ListItem(value);
        }
        builder.EndList();
        builder.EndGroup();
    }

    private static void Required(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidOperationException($"Missing required field: {fieldName}");
    }

    private static void Max(string? value, int maxLength, string fieldName)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            throw new InvalidOperationException(
                $"Field {fieldName} exceeds max length {maxLength}. Current length: {value.Length}");
    }
}
