using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

/// <summary>
/// Sage X3 Dimension Value object CCE. Web service public name: S300CCE.
/// Source metadata file: S300CCE.xml.
/// </summary>
public sealed class X3DimensionValueDto
{
    public string? DimensionType { get; set; }        // DIE, len 3
    public string? DimensionValue { get; set; }       // CCE, len 15
    public string? Description { get; set; }          // DESTRA, len 30
    public string? ShortDescription { get; set; }     // SHOTRA, len 12
    public int? IsActive { get; set; } = 2;           // ENAFLG
    public string? AccessCode { get; set; }           // ACS, len 10
    public string? CompanySiteOrGroup { get; set; }   // FCY, len 5
    public DateTime? ValidFrom { get; set; }          // VLYSTR
    public DateTime? ValidTo { get; set; }            // VLYEND
    public string? Authorization { get; set; }        // AUZ, len 20
    public int? CarryForward { get; set; }            // FRW
    public int? BudgetTracking { get; set; }          // BUDTRK
    public int? InputAllowed { get; set; }            // IPT

    public string ToX3Xml()
    {
        Validate();

        return new SageX3XmlBuilder()
            .BeginObject()
                .BeginGroup("CCE0_1")
                    .Field("DIE", DimensionType)
                    .Field("CCE", DimensionValue)
                    .Field("DESTRA", Description)
                    .Field("SHOTRA", ShortDescription)
                .EndGroup()
                .BeginGroup("CCE1_1")
                    .Field("ENAFLG", IsActive)
                    .Field("ACS", AccessCode)
                    .Field("FCY", CompanySiteOrGroup)
                    .Field("VLYSTR", ValidFrom)
                    .Field("VLYEND", ValidTo)
                    .Field("AUZ", Authorization)
                .EndGroup()
                .BeginGroup("CCE1_2")
                    .Field("FRW", CarryForward)
                    .Field("BUDTRK", BudgetTracking)
                    .Field("IPT", InputAllowed)
                .EndGroup()
            .EndObject()
            .Build();
    }

    public void Validate()
    {
        SageX3Validation.Required(DimensionType, nameof(DimensionType));
        SageX3Validation.Required(DimensionValue, nameof(DimensionValue));
        SageX3Validation.Required(Description, nameof(Description));
        SageX3Validation.Required(ShortDescription, nameof(ShortDescription));

        SageX3Validation.Max(DimensionType, 3, nameof(DimensionType));
        SageX3Validation.Max(DimensionValue, 15, nameof(DimensionValue));
        SageX3Validation.Max(Description, 30, nameof(Description));
        SageX3Validation.Max(ShortDescription, 12, nameof(ShortDescription));
        SageX3Validation.Max(AccessCode, 10, nameof(AccessCode));
        SageX3Validation.Max(CompanySiteOrGroup, 5, nameof(CompanySiteOrGroup));
        SageX3Validation.Max(Authorization, 20, nameof(Authorization));
    }
}
