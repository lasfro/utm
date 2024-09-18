using RU_NO_CRM_Functions.Models.Inbound;
using RU_NO_CRM_Functions.Services;

namespace RU.NO.CRM;

using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.Workflows;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using RU_NO_CRM_Functions.Models.Factories.Inbound;
using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.Responses;

/// <summary>
/// Processes inbound service bus account messages
/// </summary>
public class InboundMessageBusAccountsFunction(ILoggerFactory loggerFactory)
{
    public static readonly InboundMessageBusAccountsService Service = new InboundMessageBusAccountsService();
    private readonly ILogger<InboundMessageBusAccountsFunction> logger = loggerFactory.CreateLogger<InboundMessageBusAccountsFunction>();

    [Function(nameof(MapToInboundModelDistinctAccount))]
    public Task<InboundMessageBusAccountsResponse> MapToInboundModelDistinctAccount(
        [WorkflowActionTrigger] InboundMessageBusAccountsRequest requestMessage)
    {
        var responseData = Service.CreateResponseWithoutDuplicateAccounts(requestMessage);

        return Task.FromResult(responseData);
    }

    [Function(nameof(MapToInboundModelDistinctAccountFlatStructure))]
    public Task<InboundMessageBusAccountsFlatResponse> MapToInboundModelDistinctAccountFlatStructure(
        [WorkflowActionTrigger] InboundMessageBusAccountsRequest requestMessage)
    {
        var nonFlatResponseData = Service.CreateResponseWithoutDuplicateAccounts(requestMessage);

        return Task.FromResult(nonFlatResponseData.ToFlatResponse());
    }
}