namespace RU_NO_CRM_Functions.Models.Inbound.Requests;

public record InboundTsToCrmUpdateCustomerModelRequest(
    InboundAccountTradeSolution Account,
    bool IsSapCustomer = false
);