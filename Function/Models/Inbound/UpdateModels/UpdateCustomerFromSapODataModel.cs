using System.Text.Json.Serialization;

namespace RU_NO_CRM_Functions.Models.Inbound.UpdateModels;

public record UpdateCustomerFromSapODataModel
{
    public string? address1_line1 { get; set; }
    public string? telephone1 { get; set; }
    public string? name { get; set; }
    public string? address1_city { get; set; }
    public string? address1_name { get; set; }
    public string? address1_postofficebox { get; set; }
    public decimal? address1_latitude { get; set; }
    public string? address1_county { get; set; }
    public string? address1_line2 { get; set; }
    public string? address1_line3 { get; set; }
    public string? address1_country { get; set; }
    public decimal? address1_longitude { get; set; }
    public string? address1_primarycontactname { get; set; }
    public string? address1_postalcode { get; set; }
    public string? address1_stateorprovince { get; set; }
    public string? address1_telephone1 { get; set; }
    public string? address1_telephone2 { get; set; }
    public int address1_addresstypecode { get; set; }
    public int address2_addresstypecode { get; set; }
    public decimal? address2_latitude { get; set; }
    public string? address2_stateorprovince { get; set; }
    public string? address2_line1 { get; set; }
    public string? address2_line2 { get; set; }
    public string? address2_line3 { get; set; }
    public string? address2_county { get; set; }
    public string? address2_country { get; set; }
    public decimal? address2_longitude { get; set; }
    public string? address2_name { get; set; }
    public string? address2_primarycontactname { get; set; }
    public string? address2_postofficebox { get; set; }
    public string? address2_postalcode { get; set; }
    public string? address2_city { get; set; }
    public string? address2_telephone1 { get; set; }
    public string? address2_telephone2 { get; set; }
    public string? cr0c6_customers_customernumber { get; set; }
    public string? description { get; set; }
    public string? emailaddress1 { get; set; }
    public string? emailaddress2 { get; set; }
    public string? hbb_invoice_mail { get; set; }
    public string? hbb_gln { get; set; }
    [JsonPropertyName("hbb_wholesaler@odata.bind")]
    public string? hbb_wholesalerodatabind { get; set; }
    public string? accountnumber { get; set; }
    public string? hbb_member_number { get; set; }
    public string? hbb_organisasjonsnummer { get; set; }
    public int statuscode { get; set; }
    public string? telephone2 { get; set; }
}