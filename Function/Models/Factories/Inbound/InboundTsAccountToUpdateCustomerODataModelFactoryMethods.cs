using System;
using RU_NO_CRM_Functions.Models.Inbound;
using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.UpdateModels;

namespace RU_NO_CRM_Functions.Models.Factories.Inbound;

public static class InboundTsAccountToUpdateCustomerODataModelFactoryMethods
{
    public static UpdateCustomerFromTsODataModel? ToUpdateCustomerODataModel(
        this InboundTsToCrmUpdateCustomerModelRequest request)
    {
        var account = request.Account;
        bool isOffTradeOrKbs =
            "Off-Trade".Equals(request.Account.SalesChannel, StringComparison.CurrentCultureIgnoreCase) ||
            "KBS".Equals(request.Account.SalesChannel, StringComparison.CurrentCultureIgnoreCase);
        bool isOnTrade = !isOffTradeOrKbs;

        if (isOnTrade && request.IsSapCustomer)
        {
            // currently we have no data to be updated for on-trade customers from TS after SAP has become master
            return null;
        }

        // if not other scenario match, TS is owner of data
        return CreateResponseForWhenTsIsOwner(account);
    }

    private static UpdateCustomerFromTsODataModel CreateResponseForWhenTsIsOwner(InboundAccountTradeSolution account)
    {
        return new UpdateCustomerFromTsODataModel
        {
            name = account.Name,
            hbb_legal_name = account.LegalName,

            //LegalName
            hbb_organisasjonsnummer = account.VatNo,
            
            // address 1 (ship to address)
            address1_name = account.Name??"",
            address1_line1 = account.DeliveryAddress1??"",
            address1_line2 = "",
            address1_postalcode = account.DeliveryPostalCode??"",
            address1_city = account.DeliveryPostalCity??"",
            address1_latitude = account.DeliveryLatitude??0,
            address1_longitude = account.DeliveryLongitude??0,
            address1_county = account.DeliveryCounty??"",
            address1_stateorprovince = account.DeliveryMunicipality??"",

            // address 2 (invoice address)
            //address2_addresstypecode = 3, // Primary address type
            address2_name = account.Name??"",
            address2_line1 = account.InvoiceAddress1??"",
            address2_line2 = "",
            address2_county = null, 
            address2_stateorprovince = null, // null equals no update
            address2_city = account.InvoicePostalCity??"",
            address2_postalcode = account.InvoicePostalCode??"",

            telephone1 = account.Telephone1??"",

            // account number should not be updated (maybe it could be updated before sent to SAP)
            accountnumber = null,
            description = "",
            //hbb_wholesalerodatabind = isSapCustomer ? null : null, // need a mapping here and change odata bind serialization name
            hbb_wholesalerodatabind = null, // need binding here
            hbb_invoice_mail = account.InvoiceEmail,
            hbb_opening_date = account.OpeningDate,
            hbb_closing_date = account.ClosingDate,
            hbb_sales_area_square_meters = account.SalesAreaSquareMeter
        };
    }

    private static UpdateCustomerFromTsODataModel? CreateResponseForOnTradeSapCustomer()
    {
        return null;  // currently no fields updated when sap is owner
    }
}