using SageX3.SDK.Core;

namespace SageX3.SDK.Models;

public sealed class X3OptionalFieldDto
{
    public string? EntityType { get; set; }
    public string? EntityKey { get; set; }
    public string? OptionalField { get; set; }
    public string? Value { get; set; }
    public string? Description { get; set; }

    public string ToX3Xml()
    {
        return new SageX3XmlBuilder()
            .BeginObject()
            .Field("YENTTYP", EntityType)
            .Field("YENTKEY", EntityKey)
            .Field("YOPTFIELD", OptionalField)
            .Field("YVALUE", Value)
            .Field("YDES", Description)
            .EndObject()
            .Build();
    }
}
