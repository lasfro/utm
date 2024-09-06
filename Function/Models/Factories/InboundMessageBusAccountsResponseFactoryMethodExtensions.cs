using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace RU_NO_CRM_Functions.Models.Factories
{
    public static class InboundMessageBusAccountsResponseFactoryMethodExtensions
    {
        public static InboundMessageBusAccountsFlatResponse ToFlatResponse(
            this InboundMessageBusAccountsResponse response)
        {
            var responseItems = new List<InboundMessageBusAccountsFlatResponseItem>();
            foreach (var item in response.Items)
            {
                foreach (var account in item.Accounts)
                {
                    responseItems.Add(new
                        InboundMessageBusAccountsFlatResponseItem(
                            item.MessageId, item.LockToken, item.MessageValid, item.ErrorMessage, account));
                }
            }

            return new InboundMessageBusAccountsFlatResponse(responseItems);
        }
    }
}
