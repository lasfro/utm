#nullable disable

using System;

namespace RU_NO_CRM_Functions.Models.Inbound;

public record InboundAccountMessageBus
{
    public string CustomerNo { get; set; }
    public int TradesolutionId { get; set; }
    public string VatNo { get; set; }
    public string Name { get; set; }
    public string LegalName { get; set; }
    public string SalesChannel { get; set; }
    public string Type { get; set; }
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public string Email { get; set; }
    public string DeliveryAddress1 { get; set; }
    public string DeliveryAddress2 { get; set; }
    public string DeliveryPostalCode { get; set; }
    public string DeliveryPostalCity { get; set; }
    public decimal? DeliveryLatitude { get; set; }
    public decimal? DeliveryLongitude { get; set; }
    public string DeliveryCounty { get; set; }
    public string DeliveryMunicipality { get; set; }
    public string InvoiceAddress1 { get; set; }
    public string InvoiceAddress2 { get; set; }
    public string InvoicePostalCode { get; set; }
    public string InvoicePostalCity { get; set; }
    public string InvoiceCountry { get; set; }
    public string InvoiceCounty { get; set; }
    public string InvoiceEmail { get; set; }
    public string VisitingAddress1 { get; set; }
    public string VisitingAddress2 { get; set; }
    public string VisitingPostalCode { get; set; }
    public string VisitingPostalCity { get; set; }
    public string VisitingAddressNote { get; set; }
    public string DeliveryFrequency { get; set; }
    public string AlcoholLicense { get; set; }
    public DateTime AlcoholLicenseBeginDate { get; set; }
    public DateTime AlcoholLicenseEndDate { get; set; }
    public DateTime AgreementBeginDate { get; set; }
    public DateTime AgreementEndDate { get; set; }
    public string Status { get; set; }
    public bool OrderBlock { get; set; }
    public int CreditLimit { get; set; }
    public int PaymentTerms { get; set; }
    public string Owner { get; set; }
    public string PrimaryContactName { get; set; }
    public string PrimaryContactEmail { get; set; }
    public string PrimaryContactTelephone1 { get; set; }
    public int SalesTerritory { get; set; }
    public bool TankBeerCustomer { get; set; }
    public int CutNumberOfHours { get; set; }
    public string CutTimeOfDay { get; set; }
    public int CutNumberOfHoursTankBeer { get; set; }
    public string CutTimeOfDayTankBeer { get; set; }
    public string ParentLevel { get; set; }
    public string InternalWarehouse { get; set; }
    public string WholesalerWarehouse { get; set; }
    public int VatTaxCode { get; set; }
    public long GLN { get; set; }
    public DateTime LastChangedDate { get; set; }
    public string LastChangedBy { get; set; }
    public int StatisticsNumber { get; set; }
    public string BankAccountNumber { get; set; }
}


