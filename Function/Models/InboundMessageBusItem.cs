using System;

namespace RU_NO_CRM_Functions.Models;

public record InboundMessageBusItem(
    string MessageId,
    Guid LockToken,
    string ContentData,
    string ContentType,
    string ContentTransferEncoding);