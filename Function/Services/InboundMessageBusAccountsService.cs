using System;
using System.Collections.Generic;
using System.Linq;
using RU_NO_CRM_Functions.Models.Factories.Inbound;
using RU_NO_CRM_Functions.Models.Inbound;
using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.Responses;

namespace RU_NO_CRM_Functions.Services;

public class InboundMessageBusAccountsService {

    public InboundMessageBusAccountsResponse CreateResponseWithoutDuplicateAccounts(
        InboundMessageBusAccountsRequest request)
    {
        var response = MapToResponseWithPotentialDuplicates(request);

        RemoveDuplicateAccountsFromResponse(response);

        return response;
    }

    private static void RemoveDuplicateAccountsFromResponse(InboundMessageBusAccountsResponse response)
    {
        var mappings = new Dictionary<string, InboundMessageBusAccountsResponseItem>(100);

        // loop through all accounts in all messages to remove duplicates
        foreach (var responseItem in response.Items)
        {
            // create copy so we don't modify the original while looping
            var accounts = responseItem.Accounts.ToArray();
            foreach (var account in accounts)
            {
                
                if (mappings.TryGetValue(account.CustomerNo, out var currentParent)) {
                    // if item is already parented, make sure we remove it from the current parent
                    if (currentParent != null)
                    {
                        var currentItem = currentParent.Accounts.First(i => i.CustomerNo == account.CustomerNo);
                        currentParent.Accounts.Remove(account);
                    }
                }

                // map to new parent
                mappings[account.CustomerNo] = responseItem;
            }
        }
    }

    private InboundMessageBusAccountsResponse MapToResponseWithPotentialDuplicates(InboundMessageBusAccountsRequest request)
    {
        var items = new List<InboundMessageBusAccountsResponseItem>();
        foreach (var item in request.Items)
        {
            try
            {
                var itemsInMessage = item.ToInboundAccounts();
                
               items.Add(new InboundMessageBusAccountsResponseItem(
                   item.MessageId, item.LockToken, true, null, itemsInMessage
                   )); 
            }
            catch (Exception ex)
            {
                // an error occured, mark as failed
                items.Add(new InboundMessageBusAccountsResponseItem(
                    item.MessageId, item.LockToken, false, ex.Message, []));
            }
            
        }

        return new InboundMessageBusAccountsResponse(items);
    }
}