namespace RU_NO_CRM_Functions.Models.Inbound.Requests;

public record InboundSapToCrmCreateCustomerModelRequest(
    InboundAccountMessageBus Account
);