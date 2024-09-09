using System;

namespace RU_NO_CRM_Functions.Models
{
    public class OutboundAccountResponse
    {
        public string? AccountNumber { get; set; }
        public string? TradesolutionLopenummer { get; set; }
        public string Name { get; set; } = null!;
        public string? EmailAddress1 { get; set; }
        public string? EmailAddress2 { get; set; }
        public string? EmailAddress3 { get; set; }
        public string? Telephone1 { get; set; }
        public string? Telephone2 { get; set; }
        public string? Telephone3 { get; set; }
        public string? Address1PostalCode { get; set; }
        public string? Address2PostalCode { get; set; }
        public string? Address1City { get; set; }
        public string? Address2City { get; set; }
        public string? Address1Name { get; set; }
        public string? Address2Name { get; set; }
        public string? Address1County { get; set; }
        public string? Address2County { get; set; }
        public string? Address1Country { get; set; }
        public string? Address2Country { get; set; }
        public string? Address1Line1 { get; set; }
        public string? Address1Line2 { get; set; }
        public string? Address1Line3 { get; set; }
        public string? Address1Phone1 { get; set; }
        public string? Address1Phone2 { get; set; }
        public string? Address1Phone3 { get; set; }
        public string? Address1PostOfficeBox { get; set; }
        public string? Address2PostOfficeBox { get; set; }
        public string? Address1PostalCodePostOfficeBox { get; set; }
        public string? Address2PostalCodePostOfficeBox { get; set; }
        public string? Address1StateOrProvince { get; set; }
        public string? Address2StateOrProvince { get; set; }
        public string? GLN { get; set; }
        public string? VATRegistrationNumber { get; set; }
        public string? Category { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? CustomerType { get; set; }
        public string? CustomersCustomerNumber { get; set; }
        public decimal? CreditLimit { get; set; }
        public string? Address1PrimaryContactName { get; set; }
        public string? Address2PrimaryContactName { get; set; }
        public string? WareHouse { get; set; }
        public long? WareHouseId { get; set; }
        public string? Segment { get; set; }
        public DateTimeOffset? AlcoholLicenseBeginDate { get; set; }
        public DateTimeOffset? AlcoholLicenseEndDate { get; set; }
    }
}
