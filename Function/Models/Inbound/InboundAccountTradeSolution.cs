#nullable disable

using System;

namespace RU_NO_CRM_Functions.Models.Inbound;

public class InboundAccountTradeSolution
{
    public int TradesolutionId { get; set; }
    public string VatNo { get; set; }
    public string Name { get; set; }
    public string LegalName { get; set; }
    public string Telephone1 { get; set; }
    public string DeliveryAddress1 { get; set; }
    public string DeliveryPostalCode { get; set; }
    public string DeliveryPostalCity { get; set; }
    public decimal? DeliveryLatitude { get; set; }
    public decimal? DeliveryLongitude { get; set; }
    public string DeliveryCounty { get; set; }
    public string DeliveryMunicipality { get; set; }
    public string InvoiceAddress1 { get; set; }
    public string InvoicePostalCode { get; set; }
    public string InvoicePostalCity { get; set; }
    public string InvoiceEmail { get; set; }
    public string VisitingAddress1 { get; set; }
    public string VisitingPostalCode { get; set; }
    public string VisitingPostalCity { get; set; }
    public string VisitingAddressNote { get; set; }
    public int StatisticsNumber { get; set; }
    public DateTimeOffset? OpeningDate { get; set; }
    public DateTimeOffset? ClosingDate { get; set; }
    public string BankAccountNumber { get; set; }
    public int SalesAreaSquareMeter { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string SalesChannel { get; set; }
}

