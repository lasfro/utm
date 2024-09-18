using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.Workflows;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using RU_NO_CRM_Functions.Models.Factories;
using RU_NO_CRM_Functions.Models.Factories.Inbound;
using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.Responses;
using RU_NO_CRM_Functions.Models.Inbound.UpdateModels;

namespace RU_NO_CRM_Functions;

public class InboundSapAccountFunction(ILoggerFactory loggerFactory)
{
    private readonly ILogger<InboundSapAccountFunction> logger = loggerFactory.CreateLogger<InboundSapAccountFunction>();

    [Function(nameof(MapToSAPCreateCustomerModel))]
    public Task<InboundCreateCustomerFromSapODataModelResponse> MapToSAPCreateCustomerModel(
        [WorkflowActionTrigger] InboundSapToCrmCreateCustomerModelRequest request)
    {
        var responseData = request.ToCreateCustomerODataModel();

        return Task.FromResult(new InboundCreateCustomerFromSapODataModelResponse(
            responseData, 
            "SAP"));
    }

    [Function(nameof(MapToSapUpdateCustomerModel))]
    public Task<InboundUpdateCustomerFromSapODataModelResponse> MapToSapUpdateCustomerModel(
        [WorkflowActionTrigger] InboundSapToCrmUpdateCustomerModelRequest request)
    {
        var responseData = request.ToUpdateCustomerODataModel();

        return Task.FromResult(new InboundUpdateCustomerFromSapODataModelResponse(
            responseData, 
            "SAP"));
    }
}