using System;
using RU_NO_CRM_Functions.Models.Inbound;
using RU_NO_CRM_Functions.Models.Inbound.Requests;
using RU_NO_CRM_Functions.Models.Inbound.UpdateModels;

namespace RU_NO_CRM_Functions.Models.Factories.Inbound
{
    public static class InboundTsAccountToCreateCustomerODataModelFactoryMethods
    {
        public static CreateCustomerODataModel ToCreateCustomerODataModel(
            this InboundTsToCrmCreateCustomerModelRequest createCustomerModelRequest)
        {
            var account = createCustomerModelRequest.Account;

            return new CreateCustomerODataModel
            {
                hbb_tradesolution_lopenummer = account.TradesolutionId.ToString(),
                hbb_organisasjonsnummer = account.VatNo,
                hbb_type = GetInitialCrmCustomerTypeForAccount(account),
                // address 1 (ship to address)
                address1_name = account.Name,
                address1_line1 = account.DeliveryAddress1,
                //address1_line2 = account.DeliveryAddress2,
                address1_postalcode = account.DeliveryPostalCode,
                address1_city = account.DeliveryPostalCity,
                address1_county = account.DeliveryCounty,
                address1_latitude = account.DeliveryLatitude,
                address1_longitude = account.DeliveryLongitude,
                address1_stateorprovince = account.DeliveryMunicipality,

                //address2_addresstypecode = 3, // Primary address type
                
                // address 2 (invoice address)
                address2_name = account.Name,
                address2_line1 = account.InvoiceAddress1,
                //address2_line2 = account.InvoiceAddress2,
                //address2_county = account.InvoiceCounty, 
                address2_city = account.InvoicePostalCity,
                address2_postalcode = account.InvoicePostalCode,
                // visiting address not added currently, should we map to related table?
                telephone1 = account.Telephone1,
                //telephone2 = account.Telephone2,
                accountnumber = account.BankAccountNumber,
                //address1_primarycontactname = account.PrimaryContactName,
                description = account.Description,
                hbb_wholesalerodatabind = null, // need a mapping here and change odata bind serialization name
                //emailaddress1 = account.Email,
                hbb_invoice_mail = account.InvoiceEmail,
                name = account.Name,
                statuscode = GetInitialStatusCodeForAccount(account),
                hbb_customer_saleschannel = GetInitialSalesChannelForAccount(account)

                // todo: visiting address (should we add it?)
            };
        }

        private static CrmCustomerStatusReason GetInitialStatusCodeForAccount(InboundAccountTradeSolution account)
        {
            var salesChannel = account.SalesChannel?.ToLower() ?? "";

            if (salesChannel is "off-trade" or "kbs")
                return CrmCustomerStatusReason.ReadyForSAPCreation_02;// status = Active

            return CrmCustomerStatusReason.ProspectConsiderToFollowUp_14;  // status = 14 Considered for follow up
        }

        private static CrmCustomerType GetInitialCrmCustomerTypeForAccount(InboundAccountTradeSolution account)
        {
            var salesChannel = account.SalesChannel?.ToLower()??"";

            if (salesChannel is "off-trade" or "kbs")
                return CrmCustomerType.Customer;

            return CrmCustomerType.Prospect;
        }

         private static CrmSalesChannel GetInitialSalesChannelForAccount(InboundAccountTradeSolution account)
        {
            var salesChannel = account.SalesChannel?.ToLower() ?? "";

            if (salesChannel is "off-trade")
                return CrmSalesChannel.OffTrade;
            if (salesChannel is "on-trade")
                return CrmSalesChannel.OnTrade;
            if (salesChannel is "kbs")
                return CrmSalesChannel.KBS;               

            return CrmSalesChannel.Other;  
        }


    }
}