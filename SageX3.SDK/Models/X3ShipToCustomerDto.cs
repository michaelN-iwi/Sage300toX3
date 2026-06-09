using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Ship-to Customer object BPD. Web service public name: S300BPD.
/// Source metadata file: S300BPD.xml.
/// </summary>
public sealed class X3ShipToCustomerDto
{
    public string? CustomerNumber { get; set; }        // BPCNUM, len 15
    public string? ShipToCode { get; set; }            // BPAADD, len 5
    public string? CompanyCode { get; set; }           // SOC, hidden in metadata; optional
    public int? IsActive { get; set; } = 2;            // ENAFLG
    public string? Language { get; set; }              // LAN, len 3
    public string? NameLine1 { get; set; }             // BPDNAM IDX 1, len 35
    public string? NameLine2 { get; set; }             // BPDNAM IDX 2, len 35

    public string? TaxRule { get; set; }               // VACBPR
    public string? EntityUse { get; set; }             // SSTENTCOD
    public string? SalesRep1 { get; set; }             // REP IDX 1
    public string? SalesRep2 { get; set; }             // REP IDX 2

    public string? ShipmentSite { get; set; }          // STOFCY
    public string? ReceivingSite { get; set; }         // RCPFCY
    public string? DeliveryMode { get; set; }          // MDL
    public string? Carrier { get; set; }               // BPTNUM
    public int? DeliveryLeadTime { get; set; }         // DAYLTI
    public int? PrintPickTicket { get; set; }          // NPRFLG
    public int? PrintPackingSlip { get; set; }         // NDEFLG

    public string? Incoterm { get; set; }              // EECICT
    public string? IncotermTown { get; set; }          // ICTCTY
    public string? FreightAgent { get; set; }          // FFWNUM
    public string? EuVatNumber { get; set; }           // EECNUM

    public string? AddressDescription { get; set; }    // BPADES, len 20
    public string? Country { get; set; }               // CRY
    public string? CountryName { get; set; }           // CRYNAM
    public string? AddressLine1 { get; set; }          // ADDLIG1
    public string? AddressLine2 { get; set; }          // ADDLIG2
    public string? AddressLine3 { get; set; }          // ADDLIG3
    public string? PostalCode { get; set; }            // POSCOD
    public string? City { get; set; }                  // CTY
    public string? StateProvince { get; set; }         // SAT
    public string? Website { get; set; }               // FCYWEB
    public string? ExternalIdentifier { get; set; }    // EXTNUM
    public string? AddressValidation { get; set; }     // VALADR

    public string? Phone1 { get; set; }                // TEL IDX 1
    public string? Phone2 { get; set; }                // TEL IDX 2
    public string? Email1 { get; set; }                // WEB IDX 1
    public string? Email2 { get; set; }                // WEB IDX 2

    public string ToX3Xml()
    {
        Validate();

        return new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("BPD0_1")
                    .Field("BPCNUM", CustomerNumber)
                    .Field("BPAADD", ShipToCode)
                .EndGroup()
                .BeginGroup("BPD1_1")
                    .Field("ENAFLG", IsActive)
                    .Field("LAN", Language)
                    .Field("BPDNAM", NameLine1, 1)
                    .Field("BPDNAM", NameLine2, 2)
                .EndGroup()
                .BeginGroup("BPD1_2")
                    .Field("VACBPR", TaxRule)
                    .Field("SSTENTCOD", EntityUse)
                    .Field("REP", SalesRep1, 1)
                    .Field("REP", SalesRep2, 2)
                .EndGroup()
                .BeginGroup("BPD1_4")
                    .Field("STOFCY", ShipmentSite)
                    .Field("RCPFCY", ReceivingSite)
                    .Field("MDL", DeliveryMode)
                    .Field("DAYLTI", DeliveryLeadTime)
                    .Field("BPTNUM", Carrier)
                .EndGroup()
                .BeginGroup("BPD1_5")
                    .Field("NPRFLG", PrintPickTicket)
                    .Field("NDEFLG", PrintPackingSlip)
                .EndGroup()
                .BeginGroup("BPD1_6")
                    .Field("EECICT", Incoterm)
                    .Field("ICTCTY", IncotermTown)
                    .Field("FFWNUM", FreightAgent)
                .EndGroup()
                .BeginGroup("BPD1_8")
                    .Field("EECNUM", EuVatNumber)
                .EndGroup()
                .BeginGroup("BPD2_1")
                    .Field("BPADES", AddressDescription)
                    .Field("CRY", Country)
                    .Field("CRYNAM", CountryName)
                    .Field("ADDLIG1", AddressLine1)
                    .Field("ADDLIG2", AddressLine2)
                    .Field("ADDLIG3", AddressLine3)
                    .Field("POSCOD", PostalCode)
                    .Field("CTY", City)
                    .Field("SAT", StateProvince)
                    .Field("FCYWEB", Website)
                    .Field("EXTNUM", ExternalIdentifier)
                    .Field("VALADR", AddressValidation)
                .EndGroup()
                .BeginGroup("BPD2_2")
                    .Field("TEL", Phone1, 1)
                    .Field("TEL", Phone2, 2)
                .EndGroup()
                .BeginGroup("BPD2_3")
                    .Field("WEB", Email1, 1)
                    .Field("WEB", Email2, 2)
                .EndGroup()
            .EndObject()
            .Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(CustomerNumber, nameof(CustomerNumber));
        SageX3Validation.Required(ShipToCode, nameof(ShipToCode));
        SageX3Validation.Required(Language, nameof(Language));
        SageX3Validation.Required(NameLine1, nameof(NameLine1));
        SageX3Validation.Required(TaxRule, nameof(TaxRule));
        SageX3Validation.Required(Country, nameof(Country));
        SageX3Validation.Required(AddressDescription, nameof(AddressDescription));
        SageX3Validation.Required(AddressLine1, nameof(AddressLine1));
        SageX3Validation.Required(City, nameof(City));

        SageX3Validation.Max(CustomerNumber, 15, nameof(CustomerNumber));
        SageX3Validation.Max(ShipToCode, 5, nameof(ShipToCode));
        SageX3Validation.Max(Language, 3, nameof(Language));
        SageX3Validation.Max(NameLine1, 35, nameof(NameLine1));
        SageX3Validation.Max(NameLine2, 35, nameof(NameLine2));
        SageX3Validation.Max(AddressDescription, 20, nameof(AddressDescription));
        SageX3Validation.Max(Country, 3, nameof(Country));
        SageX3Validation.Max(AddressLine1, 50, nameof(AddressLine1));
        SageX3Validation.Max(AddressLine2, 50, nameof(AddressLine2));
        SageX3Validation.Max(AddressLine3, 50, nameof(AddressLine3));
        SageX3Validation.Max(PostalCode, 10, nameof(PostalCode));
        SageX3Validation.Max(City, 40, nameof(City));
        SageX3Validation.Max(StateProvince, 35, nameof(StateProvince));
        SageX3Validation.Max(Phone1, 20, nameof(Phone1));
        SageX3Validation.Max(Phone2, 20, nameof(Phone2));
        SageX3Validation.Max(Email1, 80, nameof(Email1));
        SageX3Validation.Max(Email2, 80, nameof(Email2));
    }
}
