using System.Globalization;
using System.Security;
using System.Text;

namespace SageX3.SDK.Core;

public sealed class SageX3XmlBuilder
{
    private readonly StringBuilder _xml = new();

    public SageX3XmlBuilder BeginObject()
    {
        _xml.Append("<PARAM>");
        return this;
    }

    public SageX3XmlBuilder EndObject()
    {
        _xml.Append("</PARAM>");
        return this;
    }

    public SageX3XmlBuilder BeginGroup(string groupId)
    {
        _xml.Append("<GRP ID=\"")
            .Append(SecurityElement.Escape(groupId))
            .Append("\">");

        return this;
    }

    public SageX3XmlBuilder EndGroup()
    {
        _xml.Append("</GRP>");
        return this;
    }

    public SageX3XmlBuilder Field(string name, string? value, int? index = null)
    {
        _xml.Append("<FLD NAME=\"")
            .Append(SecurityElement.Escape(name))
            .Append("\"");

        if (index.HasValue)
        {
            _xml.Append(" IDX=\"")
                .Append(index.Value.ToString(CultureInfo.InvariantCulture))
                .Append("\"");
        }

        _xml.Append(">")
            .Append(SecurityElement.Escape(value ?? string.Empty))
            .Append("</FLD>");

        return this;
    }

    public SageX3XmlBuilder Field(string name, int? value, int? index = null)
    {
        return Field(name, value?.ToString(CultureInfo.InvariantCulture), index);
    }

    public SageX3XmlBuilder Field(string name, decimal? value, int? index = null)
    {
        return Field(name, value?.ToString(CultureInfo.InvariantCulture), index);
    }

    public SageX3XmlBuilder Field(string name, DateTime? value, int? index = null)
    {
        return Field(name, value?.ToString("yyyyMMdd", CultureInfo.InvariantCulture), index);
    }

    public SageX3XmlBuilder BeginTable(string tableId, int size)
    {
        _xml.Append("<TAB ID=\"")
            .Append(SecurityElement.Escape(tableId))
            .Append("\" SIZE=\"")
            .Append(size.ToString(CultureInfo.InvariantCulture))
            .Append("\">");

        return this;
    }

    public SageX3XmlBuilder EndTable()
    {
        _xml.Append("</TAB>");
        return this;
    }

    public SageX3XmlBuilder BeginLine(int number)
    {
        _xml.Append("<LIN NUM=\"")
            .Append(number.ToString(CultureInfo.InvariantCulture))
            .Append("\">");

        return this;
    }

    public SageX3XmlBuilder EndLine()
    {
        _xml.Append("</LIN>");
        return this;
    }

    public string Build() => _xml.ToString();
}
