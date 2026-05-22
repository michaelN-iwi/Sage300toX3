using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Xml.Linq;

namespace SageX3.SDK.Core;

public sealed class SageX3WebServiceClient
{
    private readonly HttpClient _httpClient;
    private readonly SageX3Options _options;

    public SageX3WebServiceClient(
        HttpClient httpClient,
        SageX3Options options)
    {
        _httpClient = httpClient;
        _options = options;
        _options.Validate();

        var auth = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(
                $"{options.Username}:{options.Password}"));

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", auth);
    }

    public Task<SageX3WebServiceResult> SaveAsync(
        string publicName,
        string objectXml,
        CancellationToken cancellationToken = default)
    {
        var soap = BuildSoapEnvelope(
            operationName: "save",
            publicName: publicName,
            xmlParameterName: "objectXml",
            xmlPayload: objectXml);

        return SendAsync("save", soap, "saveReturn", cancellationToken);
    }

    public Task<SageX3WebServiceResult> RunAsync(
        string publicName,
        string inputXml,
        CancellationToken cancellationToken = default)
    {
        var soap = BuildSoapEnvelope(
            operationName: "run",
            publicName: publicName,
            xmlParameterName: "inputXml",
            xmlPayload: inputXml);

        return SendAsync("run", soap, "runReturn", cancellationToken);
    }

    private async Task<SageX3WebServiceResult> SendAsync(
        string soapAction,
        string soapEnvelope,
        string returnNodeName,
        CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            _options.EndpointUrl);

        request.Content = new StringContent(
            soapEnvelope,
            Encoding.UTF8,
            "text/xml");

        request.Headers.Add("SOAPAction", soapAction);

        using var response = await _httpClient.SendAsync(
            request,
            cancellationToken);

        var rawResponse = await response.Content.ReadAsStringAsync(
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return new SageX3WebServiceResult
            {
                Success = false,
                RawResponse = rawResponse,
                ErrorMessage = $"HTTP {(int)response.StatusCode} {response.ReasonPhrase}"
            };
        }

        return ParseResponse(rawResponse, returnNodeName);
    }

    private string BuildSoapEnvelope(
        string operationName,
        string publicName,
        string xmlParameterName,
        string xmlPayload)
    {
        var escapedOperationName = SecurityElement.Escape(operationName);
        var escapedPublicName = SecurityElement.Escape(publicName);
        var escapedXmlParameterName = SecurityElement.Escape(xmlParameterName);

        return $$"""
        <?xml version="1.0" encoding="utf-8"?>
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:wss="http://www.adonix.com/WSS">
          <soapenv:Header/>
          <soapenv:Body>
            <wss:{{escapedOperationName}}>
              <callContext>
                <codeLang>{{SecurityElement.Escape(_options.Language)}}</codeLang>
                <poolAlias>{{SecurityElement.Escape(_options.PoolAlias)}}</poolAlias>
                <poolId></poolId>
                <requestConfig>{{SecurityElement.Escape(_options.RequestConfig)}}</requestConfig>
              </callContext>
              <publicName>{{escapedPublicName}}</publicName>
              <{{escapedXmlParameterName}}><![CDATA[{{xmlPayload}}]]></{{escapedXmlParameterName}}>
            </wss:{{escapedOperationName}}>
          </soapenv:Body>
        </soapenv:Envelope>
        """;
    }

    private static SageX3WebServiceResult ParseResponse(
        string rawResponse,
        string returnNodeName)
    {
        try
        {
            var doc = XDocument.Parse(rawResponse);
            var resultNode = doc.Descendants()
                .FirstOrDefault(e => e.Name.LocalName == returnNodeName);

            if (resultNode == null)
            {
                return new SageX3WebServiceResult
                {
                    Success = false,
                    RawResponse = rawResponse,
                    ErrorMessage = $"Sage X3 SOAP response does not contain {returnNodeName}."
                };
            }

            var statusText = resultNode.Descendants()
                .FirstOrDefault(e => e.Name.LocalName == "status")
                ?.Value;

            int.TryParse(statusText, out var status);

            var technicalInfos = resultNode.Descendants()
                .FirstOrDefault(e => e.Name.LocalName == "technicalInfos")
                ?.Value;

            var resultXml = resultNode.Descendants()
                .FirstOrDefault(e => e.Name.LocalName == "resultXml")
                ?.Value;

            var message = resultNode.Descendants()
                .FirstOrDefault(e => e.Name.LocalName == "message")
                ?.Value;

            return new SageX3WebServiceResult
            {
                Success = status == 1,
                Status = status,
                TechnicalInfos = technicalInfos,
                ResultXml = resultXml,
                RawResponse = rawResponse,
                ErrorMessage = status == 1 ? null : message
            };
        }
        catch (Exception ex)
        {
            return new SageX3WebServiceResult
            {
                Success = false,
                RawResponse = rawResponse,
                ErrorMessage = ex.Message
            };
        }
    }
}
