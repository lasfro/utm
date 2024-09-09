using System;
using System.Collections.Generic;
using System.Text;

namespace RU_NO_CRM_Functions.Models.Factories
{
    public static class InboundMessageBusItemFactoryMethodExtensions
    {
        public static List<InboundAccount> ToInboundAccounts(this InboundMessageBusItem item)
        {
            string decodedContent;
            if ("Base64".Equals(item.ContentTransferEncoding, StringComparison.InvariantCultureIgnoreCase))
            {
                decodedContent = Encoding.UTF8.GetString(Convert.FromBase64String(item.ContentData));
            } else
            {
                decodedContent = item.ContentData;
            }
            
            var result = System.Text.Json.JsonSerializer.Deserialize<List<InboundAccount>>(decodedContent);

            return result?? [];
        }
    }
}
