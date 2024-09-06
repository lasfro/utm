namespace RU_NO_CRM_Functions.Models.Factories
{
    public static class DataverseAccountRequestMessageFactoryMethodExtensions
    {
        public static OutboundAccountResponse ToOutboundAccount(this DataverseAccountRequestMessage accountRequestMessage)
        {
            return new OutboundAccountResponse()
            {
                AccountNumber = accountRequestMessage.accountnumber,
                Name = accountRequestMessage.name,
                TradesolutionLopenummer = accountRequestMessage.hbb_tradesolution_lopenummer,
                //PreviouseTradesolutionLopenummer = accountRequestMessage.hbb_previous_tradesolution_lopenummer,  column does not exist yet
                EmailAddress1 = accountRequestMessage.emailaddress1,
                EmailAddress2 = accountRequestMessage.emailaddress2,
                EmailAddress3 = accountRequestMessage.emailaddress3,
                Telephone1 = accountRequestMessage.telephone1,
                Telephone2 = accountRequestMessage.telephone2,
                Telephone3 = accountRequestMessage.telephone3,
                Address1City = accountRequestMessage.address1_city,
                Address2City = accountRequestMessage.address2_city,
                Address1Name = accountRequestMessage.address1_name,
                Address2Name = accountRequestMessage.address2_name,
                Address1PostalCode = accountRequestMessage.address1_postalcode,
                Address2PostalCode = accountRequestMessage.address2_postalcode,
                Address1County = accountRequestMessage.address1_county,
                Address2County = accountRequestMessage.address2_county,
                Address1Country = accountRequestMessage.address1_country,
                Address2Country = accountRequestMessage.address2_country,
                Address1Line1 = accountRequestMessage.address1_line1,
                Address1Line2 = accountRequestMessage.address1_line2,
                Address1Line3 = accountRequestMessage.address1_line3,
                Address1Phone1 = accountRequestMessage.address1_telephone1,
                Address1Phone2 = accountRequestMessage.address1_telephone2,
                Address1Phone3 = accountRequestMessage.address1_telephone3,
                Address1PostOfficeBox = accountRequestMessage.address1_postofficebox,
                Address2PostOfficeBox = accountRequestMessage.address2_postofficebox,
                Address1PostalCodePostOfficeBox = string.IsNullOrWhiteSpace(accountRequestMessage.address1_postofficebox) ? null: accountRequestMessage.address1_postalcode,
                Address2PostalCodePostOfficeBox = string.IsNullOrWhiteSpace(accountRequestMessage.address2_postofficebox) ? null : accountRequestMessage.address2_postalcode,
                Address1StateOrProvince = accountRequestMessage.address1_stateorprovince,
                Address2StateOrProvince = accountRequestMessage.address2_stateorprovince,
                Address1PrimaryContactName = accountRequestMessage.address1_primarycontactname,
                Address2PrimaryContactName = accountRequestMessage.address2_primarycontactname,
                GLN = accountRequestMessage.hbb_gln,
                VATRegistrationNumber = accountRequestMessage.hbb_organisasjonsnummer,
                // blocking data needs logic if we should provide in outbound
                Category = accountRequestMessage.new_kategori_value,
                CustomerTypeId = accountRequestMessage.hbb_type,
                CustomerType = accountRequestMessage.hbb_type,
                CustomersCustomerNumber = accountRequestMessage.cr0c6_customers_customernumber,
                CreditLimit = accountRequestMessage.creditlimit,
                // ownerid?????
                //TermsOfPayment = accountRequestMessage.terms
                WareHouse = accountRequestMessage.WareHouse,
                WareHouseId = accountRequestMessage.WareHouseId,
                // look into alcohol licence details
                Segment = accountRequestMessage.Segment,
                AlcoholLicenseBeginDate = accountRequestMessage.hbb_licence_alc_fromdate,
                AlcoholLicenseEndDate = accountRequestMessage.hbb_licence_alc_todate
            };
        }
        
    }
}
