using System;
using System.Collections.Generic;
using System.Globalization;
using RU_NO_CRM_Functions.Models.Wsdl.CustomerCreate;
using RU_NO_CRM_Functions.Services;

namespace RU_NO_CRM_Functions.Models.Factories
{
    public static class OutboundAccountResponseFactoryExtensions
    {
        public static TimeZoneInfo TimeZoneInfoWEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

        public static ZfmCustomerMasterCreate ToXmlCreateCustomerRequest(this OutboundAccountResponse res)
        {

            return new ZfmCustomerMasterCreate
            {
                CentralData = CreateCentralRootData(res),
                CompanyData = CreateCmdCompanyDatas(res),
                SalesData = CreateSalesDatas(res)
            };
        }

        private static ZsiCmdSalesData[] CreateSalesDatas(OutboundAccountResponse res)
        {
            //todo: check for data that needs to be mapped
            return Array.Empty<ZsiCmdSalesData>();
        }

        private static ZsiCmdCompanyData[] CreateCmdCompanyDatas(OutboundAccountResponse res)
        {
            var d = new ZsiCmdCompanyData
            {
                CompanyCode = "2057",
                CompanyData = new CmdsEiCompanyData
                {
                    Altkn = res.CustomersCustomerNumber,
                    Akont = "51000",
                    Fdgrv = "E2",
                    Zterm = "0027"
                }
            };

            //todo: check for data that needs to be mapped
            return new ZsiCmdCompanyData[] { d };

        }

        private static ZsiCmdCentralData CreateCentralRootData(OutboundAccountResponse res)
        {
            return new ZsiCmdCentralData
            {
                Communication = new ZsiCmdCommunication
                {
                    EMail = res.EmailAddress1,
                    Telephone = res.Telephone1
                },
                Customer = res.AccountNumber,
                Address = CreateAddress(res),
                VatNumber = CreateVatNumber(res),
                Contact = CreateContactPersons(res),
                Bankdetails = CreateBankDetails(res),
                Central = CreateCentralData(res),
                SttvLicense = CreateSttvLicense(res)
            };
        }

        private static ZsiCmdKnsttv[] CreateSttvLicense(OutboundAccountResponse res)
        {
            if (res.AlcoholLicenseBeginDate == null && res.AlcoholLicenseEndDate == null)
            {
                return Array.Empty<ZsiCmdKnsttv>();
            }

            return new ZsiCmdKnsttv[]
            {
                new ZsiCmdKnsttv
                {
                    Begdt = ConvertUtcDateTimeToDateString(res.AlcoholLicenseBeginDate),
                    Enddt = ConvertUtcDateTimeToDateString(res.AlcoholLicenseEndDate),
                    Sttv = "",
                    Sttv6 = ""  //todo: map to new field to store alcohol licence number
                }
            };
        }

        private static CmdsEiVmdCentralData CreateCentralData(OutboundAccountResponse res)
        {

            if (!int.TryParse(res.TradesolutionLopenummer ?? "-1", out var tsLopenummerIntVal))
                tsLopenummerIntVal = -1;

            return new CmdsEiVmdCentralData
            {
                Bbbnr = res.GLN,
                Bbsnr = res.GLN,
                Bubkz = res.GLN,
                Stceg = "NO"+res.VATRegistrationNumber??"",
                Kukla = res.Category,
                Vbund = "EXTERN",
                Ktokd = "0001",
                FonectaId = tsLopenummerIntVal
            };
        }

        private static ZsiCmdBankdetail[] CreateBankDetails(OutboundAccountResponse res)
        {
            return Array.Empty<ZsiCmdBankdetail>();
        }

        private static ZsiCmdContactPerson[] CreateContactPersons(OutboundAccountResponse res)
        {
            var contactPersonList = new List<ZsiCmdContactPerson>();
            
            //todo: do we need to extract contacts for customer?

            return contactPersonList.ToArray();
        }

        private static Bapiad1vl CreateAddress(OutboundAccountResponse res)
        {
            var addressInfo = AddressHelperService.SplitStreetAndHouseNumber(res.Address1Line1??"");
            //todo: look at address mapping
            return new Bapiad1vl
            {
                Country = "NO",
                Langu = "O",  // key in SAP, must be make sure it is the same across all environments
                City = res.Address1City,
                County = res.Address1County,
                Name = res.Name,
                Name2 = res.Address1Name,
                PoBox = res.Address1PostOfficeBox,
                // setting as 
                PostlCod1 = string.IsNullOrEmpty(res.Address1PostOfficeBox) ? res.Address1PostalCode : null,
                PostlCod2 = !string.IsNullOrEmpty(res.Address1PostOfficeBox) ? res.Address1PostalCode : null,
                //PoBoxCit = !string.IsNullOrEmpty(res.Address1PostOfficeBox)?res.Address1City: null,
                //PoBoxCit = res.Address1City,
                //PoboxCtry = res.Address1Country,
                //HouseNo = res.Address1Line1,  // house number is omitted, as we don't have house number as a separate field in CRM
                Regiogroup = res.Address1StateOrProvince,
                Street = addressInfo.street,
                HouseNo = addressInfo.houseNumber
                
                
            };
        }

        private static ZsiCmdVat[] CreateVatNumber(OutboundAccountResponse res)
        {
            if (string.IsNullOrWhiteSpace(res.VATRegistrationNumber))
            {
                return Array.Empty<ZsiCmdVat>();
            }

            return new[]
            {
                new ZsiCmdVat
                {
                    Stceg = res.VATRegistrationNumber
                }
            };
        }

        private static string ConvertUtcDateTimeToDateString(DateTimeOffset? utcDate)
        {
            return utcDate != null
                ? TimeZoneInfo.ConvertTimeFromUtc(utcDate.Value.DateTime, TimeZoneInfoWEurope)
                    .ToString("yyyyMMdd")
                : "";
        }
    }
}
