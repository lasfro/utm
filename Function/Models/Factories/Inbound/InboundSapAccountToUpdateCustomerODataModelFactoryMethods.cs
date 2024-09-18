using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.UpdateModels;

namespace RU_NO_CRM_Functions.Models.Factories.Inbound;

public static class InboundSapAccountToUpdateCustomerODataModelFactoryMethods
{
    public static UpdateCustomerFromSapODataModel ToUpdateCustomerODataModel(
        this InboundSapToCrmUpdateCustomerModelRequest createCustomerModelRequest)
    {
        var account = createCustomerModelRequest.Account;

        return new UpdateCustomerFromSapODataModel
        {
            hbb_organisasjonsnummer = account.VatNo,
            address1_addresstypecode = 2, // ship to address type
            address1_name = account.Name,
            address1_line1 = account.DeliveryAddress1,
            address1_line2 = account.DeliveryAddress2,
            address1_city = account.DeliveryPostalCity,
            address1_county = account.DeliveryCounty,
            address1_latitude = account.DeliveryLatitude,
            address1_longitude = account.DeliveryLongitude,
            address2_addresstypecode = 1, // invoice to address type
            address2_name = account.Name,
            address2_line1 = account.InvoiceAddress1,
            address2_line2 = account.InvoiceAddress2,
            address2_county = account.InvoiceCounty, //todo: add this field to inbound schema?
            address1_country = account.InvoiceCountry,
            address2_city = account.InvoicePostalCity,
            address2_postalcode = account.InvoicePostalCode,
            // visiting address not added currently, should we map to related table?
            telephone1 = account.Telephone1,
            telephone2 = account.Telephone2,
            accountnumber = account.BankAccountNumber,
            address1_primarycontactname = account.PrimaryContactName,
            description = "",
            hbb_wholesalerodatabind = null, // need a mapping here and change odata bind serialization name
            emailaddress1 = account.Email,
            hbb_invoice_mail = account.InvoiceEmail,
            name = account.Name
        };
    }
}