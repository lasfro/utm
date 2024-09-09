using System;
using System.Collections.Generic;

namespace RU_NO_CRM_Functions.Models;

public record InboundMessageBusAccountsFlatResponse(
    List<InboundMessageBusAccountsFlatResponseItem> Items
);

public record InboundMessageBusAccountsFlatResponseItem(
    string MessageId,
    Guid LockToken,
    bool MessageValid,
    string? ErrorMessage,
    InboundAccount Account
);