using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.Workflows;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using RU_NO_CRM_Functions.Models.Factories.Inbound;
using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.Responses;
using RU_NO_CRM_Functions.Services;

namespace RU_NO_CRM_Functions;

public class InboundTsAccountFunction(ILoggerFactory loggerFactory)
{
    private readonly ILogger<InboundTsAccountFunction> logger = loggerFactory.CreateLogger<InboundTsAccountFunction>();

    [Function(nameof(MapToTsCreateCustomerModel))]
    public Task<InboundCreateCustomerODataModelResponse> MapToTsCreateCustomerModel(
        [WorkflowActionTrigger] InboundTsToCrmCreateCustomerModelRequest request)
    {
        var responseData = request.ToCreateCustomerODataModel();

        return Task.FromResult(new InboundCreateCustomerODataModelResponse(
            responseData,
            "TS"
        ));
    }

    [Function(nameof(MapToTsUpdateCustomerModel))]
    public Task<InboundUpdateCustomerFromTsODataModelResponse> MapToTsUpdateCustomerModel(
        [WorkflowActionTrigger] InboundTsToCrmUpdateCustomerModelRequest request)
    {
        var responseData = request.ToUpdateCustomerODataModel();
        bool hasDataToUpdate = responseData != null;

        var hash = HashHelper.GenerateHashForJsonSerializableType(responseData);

        return Task.FromResult(new InboundUpdateCustomerFromTsODataModelResponse(
            responseData, 
            hasDataToUpdate,
            hash,
            "TS"));
    }
}