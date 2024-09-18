using RU_NO_CRM_Functions.Models.Inbound.UpdateModels;

namespace RU_NO_CRM_Functions.Models.Inbound.Responses;

public record InboundUpdateCustomerFromSapODataModelResponse(
    UpdateCustomerFromSapODataModel ODataModel,
    string Context
);