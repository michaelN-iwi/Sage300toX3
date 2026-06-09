using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Dimension Type object DIE. Web service public name: S300DIE.
/// Source metadata file: S300DIE.xml.
/// </summary>
public sealed class X3DimensionTypeDto
{
    public string? DimensionType { get; set; }        // DIE, len 3
    public string? Description { get; set; }          // DESTRA, len 30
    public string? ShortDescription { get; set; }     // SHOTRA, len 12
    public string? ColumnHeader { get; set; }         // COLHEA, len 12
    public string? AccessCode { get; set; }           // ACS, len 10
    public string? DimensionFormat { get; set; }      // CCEFMT, len 15
    public int? AutomaticCreation { get; set; }       // CREAUT
    public int? ProjectManagement { get; set; }       // PRJMGT
    public int? Editable { get; set; }                // FLGMODACE
    public int? Entity { get; set; }                  // ENT
    public int? Envelope { get; set; }                // ENV
    public int? ProjectFlag { get; set; }             // PJMFLG
    public int? PrecommitmentFlag { get; set; }       // PCCFLG

    public string ToX3Xml()
    {
        Validate();

        return new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("DIE0_1")
                    .Field("DIE", DimensionType)
                    .Field("DESTRA", Description)
                    .Field("SHOTRA", ShortDescription)
                .EndGroup()
                .BeginGroup("DIE1_1")
                    .Field("COLHEA", ColumnHeader)
                    .Field("ACS", AccessCode)
                .EndGroup()
                .BeginGroup("DIE1_2")
                    .Field("CCEFMT", DimensionFormat)
                .EndGroup()
                .BeginGroup("DIE1_3")
                    .Field("CREAUT", AutomaticCreation)
                    .Field("PRJMGT", ProjectManagement)
                    .Field("FLGMODACE", Editable)
                    .Field("ENT", Entity)
                    .Field("ENV", Envelope)
                    .Field("PJMFLG", ProjectFlag)
                    .Field("PCCFLG", PrecommitmentFlag)
                .EndGroup()
            .EndObject()
            .Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(DimensionType, nameof(DimensionType));
        SageX3Validation.Required(Description, nameof(Description));
        SageX3Validation.Required(ShortDescription, nameof(ShortDescription));

        SageX3Validation.Max(DimensionType, 3, nameof(DimensionType));
        SageX3Validation.Max(Description, 30, nameof(Description));
        SageX3Validation.Max(ShortDescription, 12, nameof(ShortDescription));
        SageX3Validation.Max(ColumnHeader, 12, nameof(ColumnHeader));
        SageX3Validation.Max(AccessCode, 10, nameof(AccessCode));
        SageX3Validation.Max(DimensionFormat, 15, nameof(DimensionFormat));
    }
}
