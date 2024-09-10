using System;
using System.Collections.Generic;

namespace RU_NO_CRM_Functions.Models;

public record InboundMessageBusAccountsResponse (
    List<InboundMessageBusAccountsResponseItem> Items
);

public record InboundMessageBusAccountsResponseItem(
    string MessageId,
    Guid LockToken,
    bool MessageValid,
    string? ErrorMessage,
    List<InboundAccount> Accounts
);