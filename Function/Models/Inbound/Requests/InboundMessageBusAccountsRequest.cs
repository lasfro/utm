using System.Collections.Generic;

namespace RU_NO_CRM_Functions.Models.Inbound.Requests;

public record InboundMessageBusAccountsRequest(
    //List<InboundMessageBusAccountsItem> Items
    List<InboundMessageBusItem> Items
);
