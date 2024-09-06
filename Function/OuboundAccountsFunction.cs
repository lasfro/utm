using System.Text;
using System.Xml;
using System.Xml.Serialization;
using RU_NO_CRM_Functions.Models;
using RU_NO_CRM_Functions.Models.Factories;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.Workflows;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;

namespace RU.NO.CRM;

/// <summary>
/// Processes inbound service bus account messages
/// </summary>
public class OutboundAccountsFunction(ILoggerFactory loggerFactory)
{
    
    private readonly ILogger<OutboundAccountsFunction> logger = loggerFactory.CreateLogger<OutboundAccountsFunction>();

    [Function(nameof(MapToOutboundModel))]
    public Task<OutboundAccountResponse> MapToOutboundModel(
        [WorkflowActionTrigger] DataverseAccountRequestMessage requestMessage)
    {
        var responseData = requestMessage.ToOutboundAccount();

        return Task.FromResult(responseData);
    }

    [Function(nameof(MapToXmlOutboundModel))]
    public Task<Base64Response> MapToXmlOutboundModel(
        [WorkflowActionTrigger] DataverseAccountRequestMessage requestMessage)
    {
        
        var nonXmlResponseData = requestMessage.ToOutboundAccount();
        var xmlResponseData = nonXmlResponseData.ToXmlCreateCustomerRequest();

        var serializer = new XmlSerializer(typeof(ZfmCustomerMasterCreate));


        var settings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = true
        };


        using var textWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(textWriter, settings);
        
        serializer.Serialize(xmlWriter, xmlResponseData);

        var bytes = Encoding.UTF8.GetBytes(textWriter.ToString());

        return Task.FromResult(new Base64Response(
            System.Convert.ToBase64String(bytes),
            "application/xml"));
    }

    
}